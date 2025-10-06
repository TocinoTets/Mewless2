using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] protected float speed = 10f;

    void Update()
    {
        // Mueve la bala en la direcci�n establecida
        transform.position += direction * speed * Time.deltaTime;
    }
    // M�todo para establecer la direcci�n desde EnemyShooter
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
