using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_position : MonoBehaviour
{
    float background_start_postion;
    // Start is called before the first frame update
    void Start()
    {
        background_start_postion = gameObject.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Transform>().position.y > 0)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(5, background_start_postion + (GameObject.Find("Player").GetComponent<Transform>().position.y) * 0.95f , 0);
        }
    }
}
