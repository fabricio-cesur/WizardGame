using UnityEngine;

public class Jump : MonoBehaviour
{

    public float force = 13f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool grounded = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
}