using UnityEngine;
using UnityEngine.Pool;

public class BulletEnemy : Bullet
{
    [SerializeField] private float damage = 20f;
    // Referencia al pool
    public ObjectPool<BulletEnemy> poolEnemy;
    private void OnEnable()
    {
        Invoke("ReleaseToPool", 3f); // Devuelve la bala al pool despu�s de 3 segundos
    }
    // M�todo para asignar el pool desde EnemyShooter
    public void SetPool(ObjectPool<BulletEnemy> bulletPool)
    {
        poolEnemy = bulletPool;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplica da�o al jugador
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            // Destruye la bala al impactar
            Destroy(gameObject);
        }
    }
    // M�todo para devolver la bala al pool
    private void ReleaseToPool()
    {
        if (poolEnemy != null)
        {
            poolEnemy.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
