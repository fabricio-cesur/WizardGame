using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoAInstaciar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 posicion = new Vector3(0,4,0);
            Instantiate(objetoAInstaciar, posicion, Quaternion.identity);
        }       
    }
}
