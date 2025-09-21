using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private float longitudAtaque;
    [SerializeField] private float dañoAtaque;
    [SerializeField] private GameObject spawnAtack;
    protected Animator animaciones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // si se presiona el boton de ataque
        if (Input.GetMouseButtonDown(0))
        {
            //crea un rayo
            RaycastHit2D ray = Physics2D.Raycast(spawnAtack.transform.position, Vector2.right, longitudAtaque);
            animaciones.SetTrigger("atacar");
            // pregunta si no es nulo
            if (ray.collider != null)
            {
                if (ray.collider.CompareTag("Enemy"))
                {
                    GameObject gameObjectColiciono = ray.collider.gameObject;
                    //la accion si coliciona con algo
                    gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(dañoAtaque);
                }
            }
        }
    }
}
