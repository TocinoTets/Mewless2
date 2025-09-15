using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    private bool puedeMoverse = true;
    Rigidbody2D rb;
    private int contadorSaltosJugador = 0;
    private int cantidadSaltos = 1;
    [SerializeField] private bool dobleSalto = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (dobleSalto)
        {
            cantidadSaltos = 2;
        }
                
        if (puedeMoverse && Input.GetButtonDown("Jump") && contadorSaltosJugador < cantidadSaltos)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);//rb.linearVelocity es cmo un MovePosition , pero este utiliza las fisicas y el otro lo teletrasnporta
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);


            contadorSaltosJugador++;
        }

        
        
    }
    private void FixedUpdate()
    {
        if (puedeMoverse)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0)
            {
                rb.rotation = 180;
            }
            else if (horizontal > 0)
            {
                rb.rotation = 0;
            }
            Vector2 movimiento = new Vector2(horizontal * velocidad, rb.linearVelocity.y);
            rb.linearVelocity = movimiento;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("piso"))
        {
            contadorSaltosJugador = 0;
        }
    }
}
