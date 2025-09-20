using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour , IHealth
{
    [SerializeField] float health;
    Animator anim;
    public float Health { get { return health; } set { health = value; } }
    public void TakeDamage(float damage) 
    {
        health -= damage;
        //anim.SetBool("Daño", true);
        if (health <= 0)
        {
            SceneManager.LoadScene("DefeatScene");
        }
    }
    public void Death() 
    {
        Destroy(gameObject);
    }
}
