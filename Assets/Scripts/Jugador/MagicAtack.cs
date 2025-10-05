using UnityEngine;

public class MagicAtack : MonoBehaviour
{
    [SerializeField]private GameObject proyectilPrefab; // Asigna el prefab desde el inspector
    [SerializeField]private Transform puntoDisparo;     // Asigna el punto de aparición desde el inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Instancia el proyectil en la posición y rotación del punto de disparo
            Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        }
    }
}
