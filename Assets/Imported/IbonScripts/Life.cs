using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private float vidas = 3f;
    public Image corazon1;
    public Image corazon2;
    public Image corazon3;
    public Sprite corazonVacio;

    void Start()
    {
        vidas = 3f;
    }

    // COMPLETAR
    // AÑADIR UN METODO PARA DETECTAR COLISIONES
    // PONERLE LA TAG "Pinchos" A LOS PINCHOS DEL ESCENARIO
    // CUANDO COLISIONE CON UN PINCHO, LLAMAR AL MÉTODO PerderVida

    private void PerderVida()
    {
        if (vidas == 3)
        {
            corazon3.sprite = corazonVacio;
        }
        else if (vidas == 2)
        {
            corazon2.sprite = corazonVacio;
        }
        else if (vidas == 1)
        {
            corazon1.sprite = corazonVacio;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        vidas--;
        
    }
}
