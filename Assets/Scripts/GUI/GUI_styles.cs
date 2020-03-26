using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_styles : MonoBehaviour
{
    public Font font1;
    GUIStyleState text_color;
    public GUIStyle text;
    Color color = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        color = Color.black;
        color.r = 1f;
        color.g = 1f;
        text_color = new GUIStyleState();
        text_color.textColor = color;
        text = new GUIStyle();
        text.font = font1;
        text.fontSize = 50;
        text.normal = text_color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
