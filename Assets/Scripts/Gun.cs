using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    string type;
    float rate;
    float damage;
    float accuracy;
    bool canShoot = true;
    public GameObject bulletPrefab;

    public void Shoot()
    {
        if(canShoot)
        {
            switch(type)
            {
                case "handgun":
                    _handgunShoot();
                    break;
                case "machinegun":
                    _machinegunShoot();
                    break;
                case "shotgun":
                    _shotgunShoot();
                    break;
            }
        }
    }

    void _shotgunShoot()
    {
        Debug.Log("shotgun");
        canShoot = false;
        _shootBulletShotgun_();
        StartCoroutine(ShootCooldown());
    }

    void _handgunShoot()
    {
        Debug.Log("handgun");
        canShoot = false;
        _shootBullet_();
        StartCoroutine(ShootCooldown());
    }

    void _machinegunShoot()
    {
        Debug.Log("machinegun");
        canShoot = false;
        _shootBullet_();
        StartCoroutine(ShootCooldown());
    }

    void _shootBullet_()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f),Quaternion.identity) as GameObject;
        Vector2 direction = new Vector2(transform.localScale.x,0);
        bullet.GetComponent<ThrowableWeapon>().direction = direction;
        bullet.name = "bullet";
    }

    void _shootBulletShotgun_()
    {
        Debug.Log("ShotgunShootingFunction");
        List<GameObject> bullets = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f),Quaternion.identity) as GameObject;
            Vector2 direction = new Vector2(transform.localScale.x,Random.Range(-0.3f,0.3f));
            bullet.GetComponent<ThrowableWeapon>().direction = direction;
            bullet.name = "bullet";
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(1/rate);
        canShoot = true;
    }

    public void ChangeGun(string gunname)
    {
        switch (gunname)
        {
            case "handgun":
                type = "handgun";
                rate = 4;
                damage = 10;
                accuracy = 0.9f;
                break;
            case "machinegun":
                type = "machinegun";
                rate = 15;
                damage = 7;
                accuracy = 0.7f;
                break;
            case "shotgun":
                type = "shotgun";
                rate = 2;
                damage = 10;
                accuracy = 0.8f;
                break;
        }
    }
}