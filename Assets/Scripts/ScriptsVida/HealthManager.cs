using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour , IHealth
{
    [SerializeField] float health;
    protected Animator animaciones;
    
    public float Health { get { return health; } set { health = value; } }
    public void Start()
    {
        animaciones = GetComponent<Animator>();
    }

    //falta poner toda la animacion de cuando el personaje recibe daño y cuando muere
    public void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            animaciones.SetTrigger("morir");
            //Death();
        }
        else {
            animaciones.SetTrigger("daño");
        }

    }
    public void Death() 
    {
        Destroy(gameObject);
    }
}
