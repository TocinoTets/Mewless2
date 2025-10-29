using UnityEngine;
using UnityEngine.SceneManagement;

public class salida : MonoBehaviour  
{

    [SerializeField] GameObject boos;
    private SpriteRenderer sr;
    private Collider2D col;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

    }
    void Update()
    {
        if (boos == null)
        {
            col.isTrigger = false;
            sr.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            sr.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Nivel2(BOSQUE)");
        }
    }
}
