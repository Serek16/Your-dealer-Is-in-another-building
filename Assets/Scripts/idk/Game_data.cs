using UnityEngine;
using System.IO;

public class Game_data : MonoBehaviour
{
    public int timer_modifier;
    public float jump_modifier;
    public int drugs_counter;
    public int index;
    public int room_number;
    public int[] not_available_rooms;
    public int score;
    public int drug_points;
    public int numberOfRooms;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        timer_modifier = 1;
        jump_modifier = 1.0f;
        index = 0;
        score = -10;
        drug_points=0;

        canMove = true;

        numberOfRooms = 6; // This exclude model room prefab ("Room")
        DirectoryInfo dir = new DirectoryInfo("Assets/Rooms/Resources");
        FileInfo[] info = dir.GetFiles("*.meta");
       /* foreach (FileInfo f in info)
        {
            numberOfRooms++;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 4)
        {
            index = 0;
        }
        
        
    }
}
