using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs_Counter : MonoBehaviour
{
    Rect counter_position;
    Vector3 icon_position;
    // Start is called before the first frame update
    void Start()
    {
        counter_position = new Rect(Screen.width*0.1f, Screen.height*0.80f, 200, 200);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        
        GUI.Box(counter_position, "x" + GetComponentInParent<Game_data>().drugs_counter.ToString(), GetComponentInParent<GUI_styles>().text);
    }
}
