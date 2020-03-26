using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    Rect score_position;
    // Start is called before the first frame update
    void Start()
    { 
        score_position = new Rect(Screen.width*0.45f , 25, 200, 200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Box(score_position, "Score: "+GetComponent<Game_data>().score.ToString(), GetComponent<GUI_styles>().text);
    }
}
