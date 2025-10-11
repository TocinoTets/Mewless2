using UnityEngine;
using UnityEngine.Pool;

public class MagicAtack : MonoBehaviour
{
    [SerializeField]private GameObject proyectilPrefab; // Asigna el prefab desde el inspector
    [SerializeField]private Transform puntoDisparo;     // Asigna el punto de aparición desde el inspector

    ObjectPool<BulletPlayer> poolBulletPlayer;
    private void Awake()
    {
        poolBulletPlayer = new ObjectPool<BulletPlayer>(
            CreateBullet,
            ActiveBullet,
            DesactiveBullet,
            DestroyBullet,
            false, // collectionCheck
            10,    // defaultCapacity
            10     // maxSize
        );

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    // Métodos del pool
    public BulletPlayer CreateBullet()
    {
        BulletPlayer newBulletPlayer = Instantiate(proyectilPrefab).GetComponent<BulletPlayer>();
        newBulletPlayer.poolPlayer = poolBulletPlayer;
        return newBulletPlayer;
    }

    public void ActiveBullet(BulletPlayer bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public void DesactiveBullet(BulletPlayer bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void DestroyBullet(BulletPlayer bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void Shoot()
    {
        // Obtén la bala del pool
        BulletPlayer bullet = poolBulletPlayer.Get();

        // Posición y rotación
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        // Asigna la dirección según la orientación del jugador
        float escalaX = transform.localScale.x;
        Vector3 direction = (escalaX == 1f) ? Vector3.right : Vector3.left;
        bullet.SetDirection(direction);
        bullet.SetPool(poolBulletPlayer);
    }
}
