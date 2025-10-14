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
            Destroy(gameObject);//sacar esto
            animaciones.SetTrigger("morir"); // falta la animacion de el personaje y el boos, cuando esten borrar el destroy de abajo
            
            if (gameObject.CompareTag("Player"))
            {
                int vidas_personaje = LivesController.vidas_personaje;

                if (vidas_personaje <= 0)
                {
                    SceneManager.LoadScene("deat");
                }
                else
                {
                    LivesController.Instance.restar_vida();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            
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
