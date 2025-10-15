using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private float RecuperarVida = -20;//va con negarivo xq en realidad saca daño , sino tenemos q crear otra funcion q sume vida

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObjectColiciono = collision.gameObject;
        gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(RecuperarVida);
        Destroy(gameObject);
        
    }

}
