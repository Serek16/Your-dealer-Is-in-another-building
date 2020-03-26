using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shooting : MonoBehaviour
{
    float timer;
    bool start_timer;
    ParticleSystem particle;
    public List<ParticleCollisionEvent> collision;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInParent<ParticleSystem>();
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        Vector3 mouse_postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var shape = particle.shape;
        float curve;
        curve = Mathf.Asin((mouse_postion.x - position.x)/Mathf.Sqrt(Mathf.Pow(mouse_postion.x-position.x,2)+ Mathf.Pow(mouse_postion.y - position.y, 2)))*180/Mathf.PI-90;
        if(mouse_postion.y>position.y)
        {
            curve *= -1;
        }
        shape.rotation = new Vector3(0, 0, curve);
        if ((Input.GetMouseButtonDown(0)||Input.GetMouseButton(0))&&timer>=1)
        {
                particle.Play();
                timer = 0;
                start_timer = true;
            
        }
        else if(Input.GetMouseButtonUp(0))
        {
            particle.Stop();
        }
        if (start_timer == true)
        {
            timer += Time.deltaTime;
        }
        if(timer>=1)
        {
            start_timer = false;
        }
            
        
    }
    

}
