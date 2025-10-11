using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // the speed of the bullet
    public float seconds_to_destroy = 2f; // how much time till it destroys itself

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // getting the rigidbody of the bullet
        
        // asign the linear velocity to the assigned speed
        rb.linearVelocity = transform.up * speed; 

        // start the count to destroy the object
        StartCoroutine(destroyAfterSeconds(seconds_to_destroy));
    }

    void Update()
    {

    }

    IEnumerator destroyAfterSeconds(float seconds)
    {
        // destroy object after indicated seconds
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy object whenever collides with anything
        Destroy(gameObject);
    }
}
