using UnityEngine;

public class Rooms_generation : MonoBehaviour
{   
    public float roomHeight;

    bool new_room_generated = false;
    GameObject room;
    Game_data game_data;

    void Room_generate()
    {
        if (!new_room_generated)
        {
            bool room_was_generated = false;
            int room_prefab_number = Random.Range(1, game_data.numberOfRooms);
            foreach (int not_avaible_room in game_data.not_available_rooms)
            {
                if (not_avaible_room == room_prefab_number)
                {
                    room_was_generated = true;
                }
            }
            if (!room_was_generated)
            {
                room = Instantiate(Resources.Load("Room_" +GameObject.Find("Main Camera").GetComponent<Drug_system>().type_of_room+"_"+room_prefab_number) as GameObject);
                room.name = "Room" + game_data.room_number;
                room.transform.position = new Vector3(transform.position.x, transform.position.y + roomHeight, 0);
                if (GameObject.Find("Room" + (game_data.room_number - 3)))
                {
                    GameObject.Destroy(GameObject.Find("Room" + (game_data.room_number - 3)));
                }

                game_data.not_available_rooms[game_data.index] = room_prefab_number;
                game_data.index++;
                game_data.room_number++;
                new_room_generated = true;
                game_data.score += 10;
            }
            else
            {
                Room_generate();
            }
        }
    }
    void Start()
    {
        new_room_generated = false;
        roomHeight = 1000f;
        game_data = GameObject.Find("Main Camera").GetComponent<Game_data>();
    }
        
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<Transform>().position.y > transform.position.y)
        {
            Room_generate();
        }
    }
}
