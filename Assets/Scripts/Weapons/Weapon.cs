using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds;

    [Header("Bullets")]
    [SerializeField] private Transform bulletSpawnPoint;
    public Transform parentTransform;
    public Bullet Bullet;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnDestroyBullet, collectionCheck, defaultCapacity, maxSize);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Bullet bullet = objectPool.Get();
        if (bullet != null)
        {
            bullet.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.gameObject.SetActive(true);
        }
    }

    Bullet CreateBullet()
    {
        Bullet bulletInstance = Instantiate(Bullet);
        bulletInstance.ObjectPool = objectPool;
        bulletInstance.transform.SetParent(parentTransform);

        return bulletInstance;
    }

    void OnGet(Bullet bullet)
    {
        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
        }
    }

    void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}