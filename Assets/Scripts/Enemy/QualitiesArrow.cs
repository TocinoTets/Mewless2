using Unity.VisualScripting;
using UnityEngine;

public class QualitiesArrow : MonoBehaviour
{

    [SerializeField] private float velocidad_balas;
    [SerializeField] private int daño;
    private Collider2D col;

    void Start()
    {
        Destroy(gameObject, 4f);
        col = GetComponent<Collider2D>();
    }
    

    void Update()
    {
        transform.Translate(1 * Time.deltaTime * velocidad_balas, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            col.isTrigger = true;
        }
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            GameObject gameObjectColiciono = collision.gameObject;

            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(daño);
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
{
        if (collision.gameObject.CompareTag("piso"))
        {
            col.isTrigger = false;
        }
    }
}
