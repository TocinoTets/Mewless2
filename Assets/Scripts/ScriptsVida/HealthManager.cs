using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour , IHealth
{
    [SerializeField] float health;

    public float Health { get { return health; } set { health = value; } }
    public void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death() 
    {
        Destroy(gameObject);
    }
}
