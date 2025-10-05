using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2 direction;

    // EL PORYECTIL NO SE MUEVE
    // HAY QUE ARREGLARLO
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
