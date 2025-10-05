using UnityEngine;

public class Boss : EnemyManager
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animaciones.SetTrigger("atacar");
            GameObject gameObjectColiciono = collision.gameObject;
            //la accion si coliciona con algo
            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(danoAtaque);
        }
    }
}
