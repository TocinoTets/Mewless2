using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private float longitudAtaque;
    [SerializeField] private float dañoAtaque;

    [SerializeField] private GameObject spawnAtack;

    public float tiempoMaxEntreGolpes = 0.5f; // Tiempo máximo permitido entre golpes
    public float tiempoEsperaCombo = 1.0f;    // Tiempo de espera entre combos
    private int comboPaso = 0; // Paso actual del combo (0 = sin combo)
    private float tiempoUltimoGolpe = 0f;
    private bool enEsperaCombo = false;
    private float tiempoInicioEspera = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (enEsperaCombo)
        {
            if (Time.time - tiempoInicioEspera >= tiempoEsperaCombo)
            {
                enEsperaCombo = false;
            }
            else
            {
                return; // No permite iniciar combo durante el cooldown
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - tiempoUltimoGolpe > tiempoMaxEntreGolpes)
            {
                comboPaso = 0; // Reinicia el combo si pasa demasiado tiempo
            }

            comboPaso++;
            tiempoUltimoGolpe = Time.time;

            switch (comboPaso)
            {
                case 1:
                    Golpe1();
                    break;
                case 2:
                    Golpe2();
                    break;
                case 3:
                    Golpe3();
                    comboPaso = 0; // Reinicia el combo después del tercer golpe
                    enEsperaCombo = true;
                    tiempoInicioEspera = Time.time;
                    break;
            }
        }
    }
    private void atack()
    {
        //crea un rayo
        RaycastHit2D ray = Physics2D.Raycast(spawnAtack.transform.position, Vector2.right, longitudAtaque);
        // pregunta si no es nulo
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Enemy"))
            {
                GameObject gameObjectColiciono = ray.collider.gameObject;
                //la accion si colisiona con algo
                gameObjectColiciono.GetComponent<HealthManager>().TakeDamage(dañoAtaque);
            }
        }
    }
    void Golpe1()
    {
        Debug.Log("Primer golpe");
        atack();
        // PONER ANIMACION
    }

    void Golpe2()
    {
        Debug.Log("Segundo golpe");
        atack();
        // PONER ANIMACION
    }

    void Golpe3()
    {
        Debug.Log("Tercer golpe");
        atack();
        // PONER ANIMACION
    }

    public void UpDateDamage(float multiplicador)
    {
        dañoAtaque *= multiplicador;
    }
}
