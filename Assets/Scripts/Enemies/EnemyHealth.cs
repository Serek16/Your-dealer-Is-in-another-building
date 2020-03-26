using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    ParticleSystem particle;
    GameObject drugs;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        particle = GetComponentInParent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health==0)
        {
            float losuj = Random.Range(0, 4);
            if (losuj<3&&losuj>=2){ 
            drugs = Instantiate(Resources.Load("Drugs") as GameObject);
            drugs.name = "Drugs";
            drugs.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+30, gameObject.transform.position.z);
            }
            GameObject.Find("Main Camera").GetComponent<Game_data>().score += 30;
            particle.Play();
            health--;
        }
    }
    private void OnParticleCollision(GameObject gameObject)
    {
        if (gameObject.tag.Equals("Enemy"))
        { 
            gameObject.GetComponent<EnemyHealth>().health--;
        }
    }
}
