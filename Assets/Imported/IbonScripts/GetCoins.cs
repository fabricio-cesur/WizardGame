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
    // A�ADIR UN METODO PARA DETECTAR COLISIONES DE TIPO TRIGGER
    // SI EL OBJETO CON EL QUE COLISIONAMOS TIENE LA TAG "Moneda" LLAMAR AL M�TODO AddCoins PARA A�ADIR 1 MONEDA, DESPU�S, DESTRUIR LA MONEDA USANDO Object.Destroy(other.gameObject)
    // A�ADIR LA TAG "Cofre" AL COFRE EN LA ESCENA
    // SI EL OBJETO CON EL QUE COLISIONAMOS TIENE LA TAG "Cofre" LLAMAR AL M�TODO AddCoins PARA A�ADIR 50 MONEDAS,  DESPU�S, DESTRUIR EL COFRE USANDO Object.Destroy(other.gameObject)

    private void AddCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }
}
