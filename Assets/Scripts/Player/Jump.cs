using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float force = 13f;
    private Rigidbody2D rb;
    
    public float buffer_time = 0.15f;
    private float buffer_time_counter;

    private SpriteRenderer sr;
    private float player_half_height;
    private float raycast_ground_length;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = transform.Find("PlayerBody").GetComponent<SpriteRenderer>();
        player_half_height = sr.bounds.extents.y;
        raycast_ground_length = player_half_height + 0.1f;
    }

    void Update()
    {
        // press W and the counter will be set to the according value
        if (Input.GetKeyDown(KeyCode.W))
        {
            buffer_time_counter = buffer_time;
        }

        // if the counter is greater than 0 (which will be the case if it was set to the value)
        // and if it is on the ground it will jump
        if (buffer_time_counter > 0f && isGrounded())
        {
            jump();
            // the counter will be set to 0 because it just jumped
            buffer_time_counter = 0f;
        }
        else
        {
            // if not we start taking from the counter so that
            // the window to jump only last as long as you stated
            buffer_time_counter -= Time.deltaTime;
        }

        Debug.DrawRay(transform.position, Vector2.down * raycast_ground_length, Color.red);
    }

    private bool isGrounded()
    {
        // this checks if the raycast hits an object in the layer "Ground" some pixels under the player
        return Physics2D.Raycast(transform.position, Vector2.down, raycast_ground_length, LayerMask.GetMask("Ground"));
    }

    void jump()
    {
        // restart the vertical velocity to 0 so that if you add the force
        // and it is not greater than the gravity force it will still jump
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        // then the vertical up force is added to the object
        rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }
}