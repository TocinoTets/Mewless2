using TMPro;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    private static LivesController instance;

    public static LivesController Instance => instance;

    public static int vidas_personaje = 3;

    [SerializeField] private TextMeshProUGUI texto_vida;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            texto_vida.text = vidas_personaje.ToString();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void restar_vida()
    {
        vidas_personaje--;
        texto_vida.text = vidas_personaje.ToString();
    }
}
