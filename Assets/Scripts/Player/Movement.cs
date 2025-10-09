using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;

    public float acceleration = 500f;
    public float deceleration = 60f;

    private float current_velocity;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // float variable which will indicate what change to do to the position X
        // if it's 0 then no change will be applied to the X position
        float target_velocity = 0f;

        //Horizontal Movement
        if (Input.GetKey(KeyCode.A))
        {
            // the change will be the position -X according to the speed
            target_velocity = -speed; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            // the change will be the position +X according to the speed
            target_velocity = speed;
        }

        // player is trying to move
        if (target_velocity != 0)
        {
            // accelerating
            current_velocity = Mathf.MoveTowards(current_velocity, target_velocity, acceleration * Time.deltaTime);
        }
        // player is no longer trying to move
        else
        {   
            // deceleration
            current_velocity = Mathf.MoveTowards(current_velocity, 0f, deceleration * Time.deltaTime);
        }

        // setting velocity to object directly
        rb.linearVelocity = new Vector2(current_velocity, rb.linearVelocity.y);
        
    }
}
