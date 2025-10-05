using UnityEngine;

public class Wearpon : EnemyManager
{
    [SerializeField] GameObject flecha;
    [SerializeField] GameObject salidaFlecha;
    [SerializeField] private float tiempo_entre_ataque = 1f;
    protected float contador_tiempo = 0f;

    protected override void Update()
    {

        // Llamamos al Update del padre para que mantenga su comportamiento base
        base.Update();

        contador_tiempo += Time.deltaTime;

        Vector2 direccion = PlayerLocate.transform.position - transform.position;


        if (direccion.x < 0)
        {
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(180, 0, angulo * -1);
        }
        else
        {
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }


        if (Vector2.Distance(transform.position, PlayerLocate.transform.position) < distancia &&
            contador_tiempo >= tiempo_entre_ataque)
        {
            GameObject nuevaBala = Instantiate(flecha, salidaFlecha.transform.position, transform.rotation);

            Collider2D balaCollider = nuevaBala.GetComponent<Collider2D>();
            Collider2D padreCollider = GetComponentInParent<Collider2D>();

            if (balaCollider != null && padreCollider != null)
            {
                Physics2D.IgnoreCollision(balaCollider, padreCollider);
            }

            contador_tiempo = 0f;
        }

    }
}