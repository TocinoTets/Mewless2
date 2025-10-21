using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    
    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void inicio() 
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }

    public void salida()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void pausar()
    {
        Time.timeScale = 0f;
    }

    public void salir_pasusa()
    {
        Time.timeScale = 1.0f;
    }

}

