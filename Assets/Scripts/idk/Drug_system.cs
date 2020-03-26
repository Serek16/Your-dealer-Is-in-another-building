using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug_system : MonoBehaviour
{
    // Start is called before the first frame update
    public int type_of_room;
    float timer;
    float buff_timer;
    bool buffed;
    void Start()
    {
        timer = 0;
        buff_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (buffed == true)
        {
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            GameObject.Find("Main Camera").GetComponent<Game_data>().jump_modifier = 1.5f;
            buff_timer -= Time.deltaTime;
            if (buff_timer <= 0)
            {
                buffed = false;
            }
        }
        else
        {
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            GameObject.Find("Main Camera").GetComponent<Game_data>().jump_modifier = 1.0f;
        }
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 0)
        {

            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points -= 2;
            }
        }
        if (Input.GetKeyDown("f") && GameObject.Find("Main Camera").GetComponent<Game_data>().canMove)
        {
            if (GameObject.Find("Main Camera").GetComponent<Game_data>().drugs_counter > 0)
            {
                GameObject.Find("Main Camera").GetComponent<Game_data>().drugs_counter -= 1;
                GameObject.Find("Main Camera").GetComponent<Game_data>().score += 10;
                GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points += 100;
                GameObject.Find("Main Camera").GetComponent<Timer>().timer += 30.0f;
                buff_timer += 10;
                buffed = true;
            }
        }
        type_of_room = 0;
        //75 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 75)
        {
            GameObject.Find("BackgroundCity").GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
        }
        else
        {
            GameObject.Find("BackgroundCity").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        //150 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 150)
        {
            GameObject.Find("BackgroundCity").GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
        //225 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 225)
        {
            type_of_room = 1;
        }
        //300 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 300)
        {
            GameObject.Find("Main Camera").GetComponent<Game_data>().timer_modifier = Random.Range(0, 100);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<Game_data>().timer_modifier = 1;
        }
        //375 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 375)
        {
            type_of_room = 2;
        }
        //450 points
        if (GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points > 450)
        {
            GameObject.Find("Main Camera").transform.Rotate(0, 0, 0.9f);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        }
    }


    public void TakeDrugs(int drugCount)
    {
        GameObject.Find("Main Camera").GetComponent<Game_data>().drugs_counter = drugCount;
        GameObject.Find("Main Camera").GetComponent<Game_data>().score += 10;
        GameObject.Find("Main Camera").GetComponent<Game_data>().drug_points = 100 * (5-drugCount);
        GameObject.Find("Main Camera").GetComponent<Timer>().timer += 30.0f;
        buff_timer += 10;

        if (drugCount == 5) buffed = false;
        else buffed = true;
    }
}