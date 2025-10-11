using UnityEngine;
using UnityEngine.Pool;

public class BulletPlayer : Bullet
{
    // Referencia al pool
    [SerializeField] private float damage = 20f;
    public ObjectPool<BulletPlayer> poolPlayer;
    private void OnEnable()
    {
        Invoke("ReleaseToPool", 3f); // Devuelve la bala al pool después de 3 segundos
    }
    // Método para asignar el pool desde EnemyShooter
    public void SetPool(ObjectPool<BulletPlayer> bulletPool)
    {
        poolPlayer = bulletPool;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Aplica daño al jugador
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            // Destruye la bala al impactar
            Destroy(gameObject);
        }
    }
    // Método para devolver la bala al pool
    private void ReleaseToPool()
    {
        if (poolPlayer != null)
        {
            poolPlayer.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
