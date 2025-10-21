using UnityEngine;
using UnityEngine.SceneManagement;

public class FinTutorial : MonoBehaviour
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
            col.isTrigger = true;
            sr.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            sr.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}

