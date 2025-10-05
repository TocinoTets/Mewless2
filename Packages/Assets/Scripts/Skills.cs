using UnityEngine;

public class Skills : PlayerMovement
{
    [SerializeField] private bool dobleSalto = false;
    [SerializeField] protected bool paredesAgarre = false;
    private int contadorSaltosJugador = 0;
    private int cantidadSaltos = 1;
    private Collider2D col;
    private PhysicsMaterial2D sinFriccion;
    private PhysicsMaterial2D conFriccion;

    void Start()
    {
        // Creamos materiales para manejar la fricción
        sinFriccion = new PhysicsMaterial2D();
        sinFriccion.friction = 0;
        sinFriccion.bounciness = 0;


        // Obtenemos el collider del jugador
        col = GetComponent<Collider2D>();
        if (col != null)
        {
            conFriccion = col.sharedMaterial;
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
        if (Input.GetMouseButtonDown(0))
        {
            animaciones.SetTrigger("atacar");
        }
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("piso"))
        {
            contadorSaltosJugador = 0;
            col.sharedMaterial = sinFriccion;
        }
    }
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (paredesAgarre && collision.gameObject.CompareTag("paredAgarre"))
        {
            col.sharedMaterial = conFriccion;
            contadorSaltosJugador = 0;
        }
    }
}