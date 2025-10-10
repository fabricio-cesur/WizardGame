using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 100;

    void Start()
    {
        StartCoroutine(DestruirPasados5Segundos());
    }

    void Update()
    {
        Vector3 direccion = new Vector3(0, 0, 1);
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    IEnumerator DestruirPasados5Segundos()
    {
        yield return new WaitForSeconds(5);

        Object.Destroy(this.gameObject);
    } 
}
