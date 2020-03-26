using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_position : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Transform>().position.y > 0)
        {
            gameObject.transform.position = new Vector3(0, GameObject.Find("Player").GetComponent<Transform>().position.y, -10);
        }
    }
}
