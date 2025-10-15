using UnityEngine;

public class Daño : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAtack playerAtack = collision.GetComponent<PlayerAtack>();
        playerAtack.UpDateDamage(1.3f);
        Destroy(gameObject);
    }
}