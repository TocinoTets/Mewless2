using UnityEngine;

public class QualitiesArrow : MonoBehaviour
{

    [SerializeField] private float velocidad_balas;
    [SerializeField] private int daño;
    private HealthManager enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<HealthManager>();
        Destroy(gameObject, 4f);
    }


    void Update()
    {
        transform.Translate(1 * Time.deltaTime * velocidad_balas, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject gameObjectColiciono = collision.gameObject;
           
            gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(daño);
            Destroy(gameObject);
        }
    }

}
