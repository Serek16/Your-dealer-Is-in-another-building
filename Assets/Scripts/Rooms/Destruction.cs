using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    bool destructed;
    ParticleSystem ps;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        sp = GetComponent<SpriteRenderer>();
        destructed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown("t")&&destructed==false)
        {
            destructed = true;
            sp.enabled = false;
            ps.Play();
        }
        
    }
}
