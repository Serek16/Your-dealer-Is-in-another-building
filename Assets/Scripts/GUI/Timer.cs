using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    Rect timer_position;
    // Start is called before the first frame update
    void Start()
    {
        
        timer = 60.0f;
        timer_position = new Rect(25, 25, 200, 200);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else {
            timer = 0;
        }
        
    }
    private void OnGUI()
    {
        GUI.Box(timer_position, ((timer - timer % 0.01)* GameObject.Find("Main Camera").GetComponent<Game_data>().timer_modifier).ToString(),GetComponent<GUI_styles>().text);
    }
}
