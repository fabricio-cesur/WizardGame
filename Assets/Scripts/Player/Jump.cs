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
    private float player_half_width;
    private float center_raycast_ground_length;
    void Start()
    {
        // getting rigidbody of object
        rb = gameObject.GetComponent<Rigidbody2D>();
        // getting the sprite renderer of the object PlayerBody
        sr = transform.Find("PlayerBody").GetComponent<SpriteRenderer>();
        // distance between the center of the sprite and the horizontal border
        player_half_width= sr.bounds.extents.x;
        // distance between the center of the sprite and the vertical border
        player_half_height = sr.bounds.extents.y;
        // we add an extra .1 to that distance so that it touches the ground slightly
        center_raycast_ground_length = player_half_height + 0.1f;
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

        // drawing the raycast for debugging
        Debug.DrawRay(new Vector2(transform.position.x + player_half_width, transform.position.y), Vector2.down * center_raycast_ground_length);
        Debug.DrawRay(transform.position, Vector2.down * center_raycast_ground_length);
        Debug.DrawRay(new Vector2(transform.position.x - player_half_width, transform.position.y), Vector2.down * center_raycast_ground_length);
    }

    private bool isGrounded()
    {
        // origin points for the raycasts
        Vector2 center = transform.position;
        Vector2 left = new Vector2(center.x - player_half_width, center.y);
        Vector2 right = new Vector2(center.x + player_half_width, center.y);

        // check if the raycast are touching ground
        return Physics2D.Raycast(left, Vector2.down, center_raycast_ground_length, LayerMask.GetMask("Ground"))
            || Physics2D.Raycast(center, Vector2.down, center_raycast_ground_length, LayerMask.GetMask("Ground"))
            || Physics2D.Raycast(right, Vector2.down, center_raycast_ground_length, LayerMask.GetMask("Ground"));
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