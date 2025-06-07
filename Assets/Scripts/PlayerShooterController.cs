using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private float fireRange = 1f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet _bulletPrefab;
    private float _nextfireTime = 0.25f;
    private GameObject[] enemies; 


    void Start()
    {
        
    }

    private void Shoot()
        
    {
        GameObject enemy = FindNearestEnemy();

        if (enemy != null)
        {
            if (Time.time > _nextfireTime)
            {
                Bullet _bulletClone = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = _bulletClone.GetComponent<Rigidbody2D>();
                Vector2 dir = (enemy.transform.position - firePoint.position).normalized;
                rb.AddForce(dir * _bulletClone.GetSpeed(), ForceMode2D.Impulse);
                _nextfireTime = Time.time + fireRate;
            }
            
        }

    }

   

    public GameObject FindNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distanceFromPlayer = 0f;
        GameObject closest = null;
        foreach (GameObject enemy in enemies)
        {

            distanceFromPlayer = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceFromPlayer <= fireRange)
            {
                closest = enemy;
            }
            
        }

        return closest;
    }



    void Update()
    {
        Shoot();
    }



}
