using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    [SerializeField] int health;
    int Health { get { return health; } set { health = value; } }
    public void TakeDamage()
    { }
    public void Death()
    { }
}
