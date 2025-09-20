using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] protected float fuerzaSalto;
    protected bool puedeMoverse = true;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

}
