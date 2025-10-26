using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    protected GameObject PlayerLocate;
    [SerializeField] protected int distancia;
    [SerializeField] protected float speed;
    [SerializeField] protected float danoAtaque;
    protected Animator animaciones;
    protected HealthManager enemyHealth;
    [SerializeField] protected bool motion = true;
    protected float contador_tiempo = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        PlayerLocate = GameObject.FindWithTag("Player");
        enemyHealth = GetComponent<HealthManager>();
        animaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (motion)
        {
            // MOVIMIENTO DEL ENEMIGO HACIA EL PLAYER
            if (Vector2.Distance(transform.position, PlayerLocate.transform.position) < distancia)
            {
                animaciones.SetTrigger("movimiento");
                transform.position = Vector2.MoveTowards(transform.position, PlayerLocate.transform.position, speed * Time.deltaTime);

                // ROTACIÓN DEL ENEMIGO HACIA EL PLAYER (IZQUIERDA O DERECHA)
                if (PlayerLocate.transform.position.x < transform.position.x)
                {
                    // Mira a la izquierda
                    transform.localScale = new Vector3(10, 13, 1);
                }
                else
                {
                    // Mira a la derecha
                    transform.localScale = new Vector3(-10, 13, 1);
                }
            }
        }

        if (enemyHealth != null && enemyHealth.Health <= 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
            motion = false;
        }
    }
}
