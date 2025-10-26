using System.Collections.Generic;
using UnityEngine;

public class boss_2 : EnemyManager
{
    [SerializeField] private float tiempo_entre_ataque = 1f;
    [SerializeField] private List<GameObject> salidasAtaque;
    [SerializeField] private GameObject bala;
    private bool ataco = false;
    private int numero = 0;

    void LanzarPelota()
    {
        foreach (GameObject salida in salidasAtaque)
        {
            Instantiate(bala, salida.transform.position, Quaternion.identity);
        }
    }
    protected override void Update()
    {
        contador_tiempo += Time.deltaTime;

        if (contador_tiempo >= tiempo_entre_ataque)
        {
            numero = Random.Range(1, 11);
            contador_tiempo = 0f;
            Debug.Log(numero);
        }

        if (numero > 8 && ataco)
        {
            numero = Random.Range(1, 11);
        }
        else  if (numero > 8 && !ataco)
        {
            LanzarPelota();
            animaciones.SetTrigger("quieto");
            ataco = true;
        }
        else if (8 >= numero && numero >= 3 )
        {
            ataco = false;
            if (Vector2.Distance(transform.position, PlayerLocate.transform.position) < distancia)
            {
                animaciones.SetTrigger("movimiento");
                transform.position = Vector2.MoveTowards(transform.position, PlayerLocate.transform.position, speed * Time.deltaTime);

                Vector3 escala = transform.localScale; 

                if (PlayerLocate.transform.position.x < transform.position.x)
                {
                    escala.x = Mathf.Abs(escala.x);
                }
                else
                {
                    escala.x = -Mathf.Abs(escala.x);
                }

                transform.localScale = escala; 
            }
        }else
        {
            ataco = false;
            animaciones.SetTrigger("quieto");
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
