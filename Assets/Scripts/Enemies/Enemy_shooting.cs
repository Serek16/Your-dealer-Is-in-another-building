using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting : MonoBehaviour
{
    float timer;
    bool start_timer;
    ParticleSystem particle;
    Vector3 player_position;
    public List<ParticleCollisionEvent> collision;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        var shape = particle.shape;
        float curve;
        curve = Mathf.Asin((player_position.x - position.x) / Mathf.Sqrt(Mathf.Pow(player_position.x - position.x, 2) + Mathf.Pow(player_position.y - position.y, 2))) * 180 / Mathf.PI - 90;
        if (player_position.y > position.y)
        {
            curve *= -1;
        }
        shape.rotation = new Vector3(0, 0, curve);
        if (gameObject.GetComponentInParent<Enemy_alarming>().sees_player)
        {
            start_timer = true;
            if (timer >= 1)
            {
                particle.Play();
                timer = 0;
            }
        }
        else if (gameObject.GetComponentInParent<Enemy_alarming>().sees_player == false)
        {
            timer = 0;
            particle.Stop();
        }
        if (start_timer == true)
        {
            if (timer == 0)
            {
                player_position = GameObject.Find("Player").GetComponent<Transform>().position;
                player_position.y += 50;
            }
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            start_timer = false;
        }


    }


}
