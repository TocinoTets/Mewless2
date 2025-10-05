using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] protected float fuerzaSalto;
    protected bool puedeMoverse = true;
    protected Rigidbody2D rb;
    protected Animator animaciones;
    protected float horizontal;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animaciones = GetComponent<Animator>();
    }


    protected void FixedUpdate()
    {
        if (puedeMoverse)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);                
            }
            else if (horizontal > 0)
            {

                transform.localScale = new Vector3(1, 1, 1);
            }

            Vector2 movimiento = new Vector2(horizontal * velocidad, rb.linearVelocity.y);
            rb.linearVelocity = movimiento;
        }
    }

}
