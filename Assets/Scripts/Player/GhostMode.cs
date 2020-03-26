using UnityEngine;

public class GhostMode : MonoBehaviour
{
    public Movement move;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    
    [SerializeField] float speed = 500f;
    float multiplier = 1.2f;
    float v, h;
    bool ghostMode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        

        if(ghostMode)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");

            if (!GameObject.Find("Main Camera").GetComponent<Game_data>().canMove) v = h = 0;

            rb.velocity = new Vector3(speed * h, speed * v, rb.velocity.y);

            if (Input.mouseScrollDelta.y > 0 && Input.GetKey(KeyCode.LeftShift)) speed *= multiplier;
            if (Input.mouseScrollDelta.y < 0 && Input.GetKey(KeyCode.LeftShift)) speed /= multiplier;

            if (h < 0) sprite.flipX = true;
            if (h > 0) sprite.flipX = false;
        }

    }
    
    public void ToggleStatus(bool status)
    {
        ghostMode = status;
        move.enabled = !status;
        rb.isKinematic = status;
    }
}
