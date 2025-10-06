using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] protected float speed = 10f;

    void Update()
    {
        // Mueve la bala en la dirección establecida
        transform.position += direction * speed * Time.deltaTime;
    }
    // Método para establecer la dirección desde EnemyShooter
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
