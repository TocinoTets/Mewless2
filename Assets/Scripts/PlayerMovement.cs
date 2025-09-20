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


        /*esto de aca abajo es para q no se quede pegado en las paredes cuando saltas 
         se supone q le cambias al rigidbody la friccion , q es masfacil sacarlo de una pero no se como*/
        PhysicsMaterial2D sinFriccion = new PhysicsMaterial2D();
        sinFriccion.friction = 0;
        sinFriccion.bounciness = 0;

        
        Collider2D col = GetComponent<Collider2D>(); //ver si existe el colaider
        if (col != null)//si existe el colaider cambialo por el de sin friccion
        {
            col.sharedMaterial = sinFriccion;
        }
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
