using UnityEngine;

public class LAMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the position of the mouse in screen
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // get the vector as the stepts to get to the position of the mouse
        Vector2 direction = mouse_position - transform.position;

        // Atan2 creates a radian with the positions, and then with Rad2Deg it converts to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // we change the object's rotation according to the angle given
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
