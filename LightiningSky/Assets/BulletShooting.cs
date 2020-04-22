using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour, ShootingInteface
{

    BulletInfo bulletInfo;

    void Start()
    {
        bulletInfo = GetComponent<BulletInfo>();
    }

    public IEnumerator Shoot()
    {
        if (!bulletInfo.m_oneTimeSpawn)
        {
            bulletInfo.m_oneTimeSpawn = true;
            GameObject bullet = Instantiate(bulletInfo.m_bulletPrfab, this.transform.position, this.transform.rotation);
            bullet.transform.SetParent(bulletInfo.m_parent.transform);
            bullet.GetComponent<DestroyObject>().m_timeAfterDestroy = bulletInfo.m_timeAfterDestroy;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Vector3 direction = this.transform.up;
            rb.AddForce(direction * bulletInfo.Speed, ForceMode.Impulse);

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