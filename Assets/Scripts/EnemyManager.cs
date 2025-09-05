using Unity.VisualScripting;
using UnityEngine;

public class EnemyMnager : MonoBehaviour
{
    private GameObject PlayerLocate;
    [SerializeField] private int distancia;
    [SerializeField] private float speed;
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
}
