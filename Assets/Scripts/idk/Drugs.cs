using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject.Find("Main Camera").GetComponent<Game_data>().drugs_counter++;
            GameObject.Destroy(gameObject);
        }
    }
}
