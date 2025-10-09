using UnityEngine;

public class MovementBase : MonoBehaviour
{
    public float speed = 5f;            // Velocidad de movimiento
    public float rotationSpeed = 10f;   // Velocidad de rotación
    public float jumpForce = 7f;        // Fuerza del salto
    private bool tocaSuelo = true;     // Indica si el jugador está en el suelo

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        // Movimiento con WASD
        if (Input.GetKey(KeyCode.W))
            direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            direction += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        if (direction != Vector3.zero)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Salto, solo puede saltar si tocaSuelo es verdadero
        if (Input.GetKeyDown(KeyCode.Space) && tocaSuelo)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            tocaSuelo = false;
        }
    }

    // COMPLETAR
    void OnCollisionEnter(Collision collision)
    {
       // SI ESTÁ TOCANDO EL SUELO, PONER LA VARIABLE tocaSuelo A TRUE
       // (El suelo tiene la Tag "Suelo")
    }
}
