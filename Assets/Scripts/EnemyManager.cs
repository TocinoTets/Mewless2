using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    private GameObject PlayerLocate;
    [SerializeField] private int distancia;
    [SerializeField] private float speed;

    [SerializeField] private float danoAtaque;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerLocate = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO DEL ENEMIGO HACIA EL PLAYER
        if (Vector2.Distance(transform.position, PlayerLocate.transform.position) < distancia)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerLocate.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject gameObjectColiciono = collision.gameObject;
            //la accion si coliciona con algo
            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(danoAtaque);
        }
    }
}
