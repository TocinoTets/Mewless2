using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject boos;

    private void Update()
    {
        if (boos == null)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
