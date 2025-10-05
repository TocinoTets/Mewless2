using UnityEngine;

public class MagicAtack : MonoBehaviour
{
    [SerializeField]private GameObject proyectilPrefab; // Asigna el prefab desde el inspector
    [SerializeField]private Transform puntoDisparo;     // Asigna el punto de aparici�n desde el inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Instancia el proyectil en la posici�n y rotaci�n del punto de disparo
            Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        }
    }
}
