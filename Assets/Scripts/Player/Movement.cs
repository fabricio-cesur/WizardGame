using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;            
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

        //WASD Movement
        if (Input.GetKey(KeyCode.W)) { direction += Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { direction += Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { direction += Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { direction += Vector2.right; }

        if (direction != Vector2.zero)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
