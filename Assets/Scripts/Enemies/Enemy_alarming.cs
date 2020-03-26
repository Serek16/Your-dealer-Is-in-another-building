using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_alarming : MonoBehaviour
{
    public LayerMask mask;
    public bool alarmed;
    public bool sees_player;
    RaycastHit2D player_detection;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        sees_player=false;
        alarmed = false;
    }
    RaycastHit2D[] result;
    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(GameObject.Find("Player").transform.position.x - gameObject.transform.position.x, GameObject.Find("Player").transform.position.y+10 - gameObject.transform.position.y);
        player_detection = Physics2D.Raycast(gameObject.transform.position,direction, 1000,mask);
        
        if(player_detection.collider.tag=="Player")
        {
            sees_player = true;
            alarmed = true;
        }
        else
        {
            sees_player = false;
        }
    }
}
