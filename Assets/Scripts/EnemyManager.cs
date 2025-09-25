using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    private GameObject PlayerLocate;
    [SerializeField] private int distancia;
    [SerializeField] private float speed;
    [SerializeField] private float danoAtaque;
    [SerializeField] private float distancia_ataque;
    protected Animator animaciones;
    private HealthManager enemyHealth;
    private bool motion = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PlayerLocate = GameObject.FindWithTag("Player");
        enemyHealth = GetComponent<HealthManager>();
        animaciones = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animaciones.SetTrigger("atacar");
            GameObject gameObjectColiciono = collision.gameObject;
            //la accion si coliciona con algo
            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(danoAtaque);
        }
    }
}
