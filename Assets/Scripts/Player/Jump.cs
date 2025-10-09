using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float force = 13f;
    public float input_buffer_time = 0.1f;
    private Rigidbody2D rb;
    private Queue<KeyCode> input_buffer; // queue to save the inputs of the jump
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        input_buffer = new Queue<KeyCode>();
    }

    private bool grounded = true;
    void Update()
    {
        // if you press W it will be saved on the queue
        if (Input.GetKeyDown(KeyCode.W))
        {
            input_buffer.Enqueue(KeyCode.W);
            Invoke("removeAction", input_buffer_time);
        }

        // if you're touching ground
        if (grounded)
        {
            // if the input buffer has more than 1 key pressed saved
            if (input_buffer.Count > 0)
            {
                // if that next pressed key is the jump key
                if (input_buffer.Peek() == KeyCode.W)
                {
                    // object jumps
                    rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                    // and it's not touching the ground anymore
                    grounded = false;

                    // removing the action from the queue
                    input_buffer.Dequeue();
                }
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    void removeAction()
    {   
        if (input_buffer.Count > 0)
        {
            input_buffer.Dequeue();
        }
    }
}