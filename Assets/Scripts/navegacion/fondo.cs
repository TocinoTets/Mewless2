using UnityEngine;

public class fondo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject gameObjectColiciono = collision.gameObject;
            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(100);
        }
        else if (collision.gameObject.CompareTag("piso"))
        {
            Destroy(collision.gameObject);
        }
    }
}
