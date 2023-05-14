using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shots : MonoBehaviour
{

    private float LastShoot;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public Transform LBulletSpawn;
    public Transform RBulletSpawn;
    public int BulletDamage = 10;

    void Start()
    {
        
    }


    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }



    private void Shoot()
    {
        GameObject newBulletPrefab = BulletPrefab;

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.up;
        else direction = Vector3.up;

        GameObject bullet = Instantiate(newBulletPrefab, BulletSpawn.position + direction * 0.1f, Quaternion.identity);
        GameObject bullet1 = Instantiate(newBulletPrefab, LBulletSpawn.position + direction * 0.1f, Quaternion.identity);
        GameObject bullet2 = Instantiate(newBulletPrefab, RBulletSpawn.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
        bullet1.GetComponent<Bullet>().SetDirection(direction);
        bullet2.GetComponent<Bullet>().SetDirection(direction);
    }
}
