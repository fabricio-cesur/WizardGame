using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
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
        float horizontal_direction = 0f;

        //Horizontal Movement
        if (Input.GetKey(KeyCode.A))
        {
            // subtract to X position each frame
            horizontal_direction = -1f; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            // add to X position each frame
            horizontal_direction = 1f;
        }

        // setting velocity to object directly
        rb.linearVelocity = new Vector2(horizontal_direction * speed, rb.linearVelocity.y);
        
    }
}
