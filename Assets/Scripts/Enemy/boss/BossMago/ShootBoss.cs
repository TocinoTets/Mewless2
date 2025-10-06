using UnityEngine;
using UnityEngine.Pool;

public class ShootBoss : MonoBehaviour
{
    [SerializeField]private GameObject projectilPrefab; // Asigna el prefab en el inspector
    private GameObject playerLocate;

    [SerializeField] private float shootInterval = 2f; // Intervalo entre disparos en segundos
    private float shootTimer = 2f;

    ObjectPool<BulletEnemy> poolBulletEnemy;
    private void Awake()
    {
        poolBulletEnemy = new ObjectPool<BulletEnemy>(
            CreateBullet,
            ActiveBullet,
            DesactiveBullet,
            DestroyBullet,
            false, // collectionCheck
            10,    // defaultCapacity
            10     // maxSize
        );

    }
    // Métodos del pool
    public BulletEnemy CreateBullet()
    {
        BulletEnemy newBulletEnemy = Instantiate(projectilPrefab).GetComponent<BulletEnemy>();
        newBulletEnemy.poolEnemy = poolBulletEnemy;
        return newBulletEnemy;
    }

    public void ActiveBullet(BulletEnemy bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public void DesactiveBullet(BulletEnemy bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void DestroyBullet(BulletEnemy bullet)
    {
        Destroy(bullet.gameObject);
    }
    private void Start()
    {
       playerLocate = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        // Obtén la bala del pool
        BulletEnemy bullet = poolBulletEnemy.Get();

        // Posición y rotación
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        // Asigna la dirección y el pool
        Vector3 direction = (playerLocate.transform.position - transform.position).normalized;
        bullet.SetDirection(direction);
        bullet.SetPool(poolBulletEnemy);
    }
}
