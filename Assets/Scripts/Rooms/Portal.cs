using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            string curRoomNumber = (transform.parent.name.Remove(0, 4));
            string nextRoomName = "Room" + (int.Parse(curRoomNumber) + 1);

            GameObject nextRoom = GameObject.Find(nextRoomName);

            collision.gameObject.transform.position = new Vector3(nextRoom.transform.Find("PortalExit").transform.position.x, nextRoom.transform.Find("PortalExit").transform.position.y-10, nextRoom.transform.Find("PortalExit").transform.position.z);
        }
    }
}
