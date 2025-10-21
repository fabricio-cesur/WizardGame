using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            restart();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
            Debug.Log("Player was damaged. HP: " + hp);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            hp = 0;
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
