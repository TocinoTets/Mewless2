using UnityEngine;

public class PlayerMovenment : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float longitudAtaque;
    [SerializeField] private GameObject spawnAtack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // si se presiona el boton de ataque
        if (Input.GetMouseButtonDown(0))
        {
            //crea un rayo
            RaycastHit2D ray = Physics2D.Raycast(spawnAtack.transform.position, Vector2.right, longitudAtaque);

            // pregunta si no es nulo
            if (ray.collider != null)
            {
                if (ray.collider.CompareTag("Enemy"))
                {
                    GameObject gameObjectColiciono = ray.collider.gameObject;
                    //la accion si coliciona con algo
                    Destroy(gameObjectColiciono);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void FixedUpdate()
    {
        //movimienot del jugador
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(Horizontal * Time.deltaTime * velocidad, 0, 0);
        transform.Translate(0, Vertical * Time.deltaTime * velocidad, 0);
    }
}
