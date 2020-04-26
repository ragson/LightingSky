using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour, ShootingInteface
{

    BulletInfo bulletInfo;

    public void Start()
    {

        bulletInfo = GetComponent<BulletInfo>();
       
        bulletInfo.m_oneTimeSpawn = false;
    }
    AudioSource audioSource;
    Rigidbody rb;
    public IEnumerator Shoot()
    {
        if (!bulletInfo.m_oneTimeSpawn)
        {
            bulletInfo.m_oneTimeSpawn = true;
            GameObject bullet = Instantiate(bulletInfo.m_bulletPrfab, this.transform.position, Quaternion.identity);
            bullet.transform.SetParent(bulletInfo.m_parent.transform);
            bullet.GetComponent<DestroyBulletItself>().m_timeAfterDestroy = bulletInfo.m_timeAfterDestroy;
            rb = bullet.GetComponent<Rigidbody>();
            Vector3 direction = bulletInfo.m_bullettargetDiection.position - this.transform.position;
            rb.AddForce(direction * bulletInfo.m_bulletSpeed);
            
            yield return new WaitForSeconds(bulletInfo.m_bulletShootTime);
            bulletInfo.m_oneTimeSpawn = false;
        }


    }

    void Update()
    {
        StartCoroutine(Shoot());
    }
}

public interface ShootingInteface
{
    IEnumerator Shoot();
}