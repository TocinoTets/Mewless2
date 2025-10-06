using System.Collections.Generic;
using UnityEngine;

public class TpBoss : MonoBehaviour
{
    //Puntos de destino
    [SerializeField] private List<GameObject> puntosDestino;

    // Configuración de movimiento
    [SerializeField] private float tiempoEntreTp = 2f;
    private float temporizador;
    private int ultimoDestino = -1;
    void Start()
    {
        temporizador = tiempoEntreTp;
        Teletransportar();
    }

    void Update()
    {
        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            Teletransportar();
            temporizador = tiempoEntreTp;
        }
    }

    void Teletransportar()
    {
        if (puntosDestino != null && puntosDestino.Count > 1)
        {
            int indice;
            do
            {
                indice = Random.Range(0, puntosDestino.Count);
            } while (indice == ultimoDestino);

            transform.position = puntosDestino[indice].transform.position;
            ultimoDestino = indice;
        }
        else if (puntosDestino != null && puntosDestino.Count == 1)
        {
            transform.position = puntosDestino[0].transform.position;
            ultimoDestino = 0;
        }
    }
}
