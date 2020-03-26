using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject gameObject)
    {
        if (gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<PlayerHealth>().health--;
        }
    }
}
