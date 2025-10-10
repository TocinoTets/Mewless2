using UnityEngine;

public class SpawnTrunk : EnemyManager
{
    [SerializeField] GameObject tronco;
    [SerializeField] private float tiempo_entre_tronco = 1f;

    protected override void Update()
    {
        contador_tiempo += Time.deltaTime;
        if (contador_tiempo >= tiempo_entre_tronco)
        {
            GameObject nuevoTronco = Instantiate(tronco, gameObject.transform.position, transform.rotation);
            contador_tiempo = 0f;
        }
    }
}
