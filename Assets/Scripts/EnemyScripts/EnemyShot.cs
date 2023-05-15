using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float shootingCooldown = 1f;

    private GameObject player;
    private float lastShotTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
        {

            return;
        }

        if (Time.time - lastShotTime >= shootingCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Vector3 direction = (player.transform.position - bulletSpawn.position).normalized;
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }
}
