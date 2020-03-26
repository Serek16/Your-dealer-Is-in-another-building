using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_wall_detector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (GetComponentInParent<Movement>().onGround == false)
        {
            GetComponentInParent<Movement>().right_stop = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        GetComponentInParent<Movement>().right_stop = false;
    }
}
