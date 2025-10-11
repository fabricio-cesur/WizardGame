using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet_prefab;
    public Transform fire_spot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }

    private void shootBullet()
    {
        GameObject bullet = Instantiate(bullet_prefab, fire_spot.position, fire_spot.rotation);
    }
}
