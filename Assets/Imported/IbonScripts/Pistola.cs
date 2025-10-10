using UnityEngine;

public class Pistola : MonoBehaviour
{
    public GameObject bala;
    public Transform transformPistola;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bala, transformPistola.position, transformPistola.rotation);
        }
    }
}
