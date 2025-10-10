using UnityEngine;

public class TrunkMotion : MonoBehaviour
{
    [SerializeField] private float velocidad_tronco;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, -velocidad_tronco);
    }
}
