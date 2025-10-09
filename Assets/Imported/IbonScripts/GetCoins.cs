using TMPro;
using UnityEngine;

public class GetCoins : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public int coins = 0;

    void Start()
    {
        coinsText.text = coins.ToString();
    }
    // COMPLETAR
    // AÑADIR UN METODO PARA DETECTAR COLISIONES DE TIPO TRIGGER
    // SI EL OBJETO CON EL QUE COLISIONAMOS TIENE LA TAG "Moneda" LLAMAR AL MÉTODO AddCoins PARA AÑADIR 1 MONEDA, DESPUÉS, DESTRUIR LA MONEDA USANDO Object.Destroy(other.gameObject)
    // AÑADIR LA TAG "Cofre" AL COFRE EN LA ESCENA
    // SI EL OBJETO CON EL QUE COLISIONAMOS TIENE LA TAG "Cofre" LLAMAR AL MÉTODO AddCoins PARA AÑADIR 50 MONEDAS,  DESPUÉS, DESTRUIR EL COFRE USANDO Object.Destroy(other.gameObject)

    private void AddCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }
}
