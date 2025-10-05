using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Archer: EnemyManager
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
            transform.rotation = Quaternion.Euler(0, 180, 0 );
        }
        else
        {
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        //sacar esto cuando el enemigo tenga la animacion de morir
        if (enemyHealth != null && enemyHealth.Health <= 0)
        {
            Destroy(gameObject);
        }

    }    
}


