using UnityEngine;
using UnityEngine.SceneManagement;

public class salida : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinScene");
        }
    }
}
