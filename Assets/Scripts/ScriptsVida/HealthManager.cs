using UnityEngine;

public class HealthManager : MonoBehaviour , IHealth
{
    [SerializeField] float health;
    Animator anim;
    public float Health { get { return health; } set { health = value; } }
    public void TakeDamage(float damage) 
    {
        Debug.Log("ay");
        health -= damage;
        anim.SetBool("Da�o", true);
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death() { }
}
