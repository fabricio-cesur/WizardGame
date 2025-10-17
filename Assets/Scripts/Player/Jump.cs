using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float force = 13f;
    private Rigidbody2D rb;

    private bool jumping;
    public float coyote_time = 0.18f;
    private float coyote_time_counter;
    public float buffer_time = 0.15f;
    private float buffer_time_counter;

    private SpriteRenderer sr;
    private float player_half_height;
    private float player_half_width;
    private float center_raycast_ground_length;
    private float ray_offset = 0.01f;

    private LayerMask ground_layermask;
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
        center_raycast_ground_length = player_half_height + 0.05f;
        ground_layermask = LayerMask.GetMask("Ground");
    }

    void Update()
    {

        if (isGrounded())
        {
            coyote_time_counter = coyote_time;
        }
        else
        {
            coyote_time_counter -= Time.deltaTime;
        }

        if (isFalling() && jumping)
        {
            jumping = false;
        }

        // press W and the counter will be set to the according value
        if (Input.GetKeyDown(KeyCode.W))
        {
            buffer_time_counter = buffer_time;
        }
        else
        {
            buffer_time_counter -= Time.deltaTime;
        }

        // if the counter is greater than 0 (which will be the case if it was set to the value)
        // and if it is on the ground it will jump
        if (coyote_time_counter > 0f && buffer_time_counter > 0f && !jumping)
        {
            jumping = true;
            jump();
            // the counter will be set to 0 because it just jumped
            buffer_time_counter = 0f;
            coyote_time_counter = 0f;
        }

        // drawing the raycast for debugging
        Debug.DrawRay(new Vector2(transform.position.x - player_half_width + ray_offset, transform.position.y), Vector2.down * center_raycast_ground_length, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * center_raycast_ground_length, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x + player_half_width - ray_offset, transform.position.y), Vector2.down * center_raycast_ground_length, Color.red);
    }

    private bool isGrounded()
    {
        // origin points for the raycasts
        Vector2 center = transform.position;
        Vector2 left = new Vector2(center.x - player_half_width + ray_offset, center.y);
        Vector2 right = new Vector2(center.x + player_half_width - ray_offset, center.y);

        // check if the raycast are touching ground
        return Physics2D.Raycast(left, Vector2.down, center_raycast_ground_length, ground_layermask)
            || Physics2D.Raycast(center, Vector2.down, center_raycast_ground_length, ground_layermask)
            || Physics2D.Raycast(right, Vector2.down, center_raycast_ground_length, ground_layermask);
    }

    void jump()
    {
        // restart the vertical velocity to 0 so that if you add the force
        // and it is not greater than the gravity force it will still jump
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        // then the vertical up force is added to the object
        rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }

    private bool isFalling()
    {
        return rb.linearVelocity.y < 0f;
    }
}