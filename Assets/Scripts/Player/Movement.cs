using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    ParticleSystem particle;
    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D playerBody;
    private int xSpeed = 0;
    public bool left_stop;
    public bool right_stop;
    public int maxSpeed;
    public int acceleration;
    public int jumpHeight;
    public bool onGround = false;
    Game_data gameData;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        gameData = GameObject.Find("Main Camera").GetComponent<Game_data>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = gameData.canMove;
        if (canMove)
        {
            if (right_stop == false)
            {
                if (Input.GetKey("d") && xSpeed < maxSpeed)
                {
                    sprite.flipX = false;
                    if (particle.shape.rotation.z < 30 && particle.shape.rotation.z > -30)
                    {
                        animator.Play("Player_Move_0");
                    }
                    else if (particle.shape.rotation.z >= 30 && particle.shape.rotation.z < 60)
                    {
                        animator.Play("Player_Move_30");
                    }
                    else if (particle.shape.rotation.z >= 60 && particle.shape.rotation.z < 80)
                    {
                        animator.Play("Player_Move_60");
                    }
                    else if (particle.shape.rotation.z >= 80 && particle.shape.rotation.z <= 90)
                    {
                        animator.Play("Player_Move_80");
                    }
                    else if (particle.shape.rotation.z <= -30 && particle.shape.rotation.z > -60)
                    {
                        animator.Play("Player_Move_-30");
                    }
                    else if (particle.shape.rotation.z <= -60 && particle.shape.rotation.z > -80)
                    {
                        animator.Play("Player_Move_-60");
                    }
                    else if (particle.shape.rotation.z <= -80 && particle.shape.rotation.z >= -90)
                    {
                        animator.Play("Player_Move_-80");
                    }
                    xSpeed = acceleration;
                }
            }
            if (left_stop == false)
            {
                if (Input.GetKey("a") && xSpeed > -maxSpeed)
                {
                    sprite.flipX = true;

                    if (particle.shape.rotation.z <= -150 || particle.shape.rotation.z > 150)
                    {
                        animator.Play("Player_Move_0");
                    }
                    else if (particle.shape.rotation.z > 120 && particle.shape.rotation.z <= 150)
                    {
                        animator.Play("Player_Move_30");
                    }
                    else if (particle.shape.rotation.z > 100 && particle.shape.rotation.z <= 120)
                    {
                        animator.Play("Player_Move_60");
                    }
                    else if (particle.shape.rotation.z > 90 && particle.shape.rotation.z <= 100)
                    {
                        animator.Play("Player_Move_80");
                    }
                    else if (particle.shape.rotation.z > -150 && particle.shape.rotation.z < -120)
                    {
                        animator.Play("Player_Move_-30");
                    }
                    else if (particle.shape.rotation.z >= -120 && particle.shape.rotation.z < -100)
                    {
                        animator.Play("Player_Move_-60");
                    }
                    else if (particle.shape.rotation.z >= -100 && particle.shape.rotation.z < -90)
                    {
                        animator.Play("Player_Move_-80");
                    }
                    xSpeed = -acceleration;
                }
            }
            if ((!Input.GetKey("d") && !Input.GetKey("a")) || left_stop == true || right_stop == true)
            {
                if ((particle.shape.rotation.z >= -90 && particle.shape.rotation.z <= 90))
                {
                    sprite.flipX = false;
                }
                else
                {
                    sprite.flipX = true;
                }
                if ((particle.shape.rotation.z < 30 && particle.shape.rotation.z > -30) || (particle.shape.rotation.z <= -150 || particle.shape.rotation.z > 150))
                {
                    animator.Play("Player_Idle_0");
                }
                else if ((particle.shape.rotation.z >= 30 && particle.shape.rotation.z < 60) || (particle.shape.rotation.z > 120 && particle.shape.rotation.z <= 150))
                {
                    animator.Play("Player_Idle_30");
                }
                else if ((particle.shape.rotation.z >= 60 && particle.shape.rotation.z < 80) || (particle.shape.rotation.z > 100 && particle.shape.rotation.z <= 120))
                {
                    animator.Play("Player_Idle_60");
                }
                else if ((particle.shape.rotation.z >= 80 && particle.shape.rotation.z <= 90) || (particle.shape.rotation.z > 90 && particle.shape.rotation.z <= 100))
                {
                    animator.Play("Player_Idle_80");
                }
                else if ((particle.shape.rotation.z <= -30 && particle.shape.rotation.z > -60) || (particle.shape.rotation.z > -150 && particle.shape.rotation.z < -120))
                {
                    animator.Play("Player_Idle_-30");
                }
                else if ((particle.shape.rotation.z <= -60 && particle.shape.rotation.z > -80) || (particle.shape.rotation.z >= -120 && particle.shape.rotation.z < -100))
                {
                    animator.Play("Player_Idle_-60");
                }
                else if ((particle.shape.rotation.z <= -80 && particle.shape.rotation.z >= -90) || (particle.shape.rotation.z >= -100 && particle.shape.rotation.z < -90))
                {
                    animator.Play("Player_Idle_-80");
                }
                if (xSpeed > 0)
                {
                    xSpeed -= acceleration / 2;
                }
                else if (xSpeed < 0)
                {
                    xSpeed += acceleration / 2;
                }
            }
            if (Input.GetKey("w") && onGround == true)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight * GameObject.Find("Main Camera").GetComponent<Game_data>().jump_modifier);
            }
            playerBody.velocity = new Vector2(xSpeed, playerBody.velocity.y);
        }
        
    }
}
