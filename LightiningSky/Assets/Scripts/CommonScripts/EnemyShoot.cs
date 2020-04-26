using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour, ShootingInteface
{
    BulletInfo bulletInfo;

    void Start()
    {
        bulletInfo = GetComponent<BulletInfo>();
    }

    int m_tempCnt = 0;
    Vector3 direction;
    public IEnumerator Shoot()
    {

        // if (m_tempCnt < bulletInfo.m_bulletCount)
        {
            if (!bulletInfo.m_oneTimeSpawn)
            {
                bulletInfo.m_oneTimeSpawn = true;
                GameObject bullet = Instantiate(bulletInfo.m_bulletPrfab, this.transform.position, this.transform.rotation);
                bullet.transform.SetParent(bulletInfo.m_parent.transform);
                bullet.GetComponent<DestroyBulletItself>().m_timeAfterDestroy = bulletInfo.m_timeAfterDestroy;
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                //  Vector3 direction = this.transform.up;
                if (GameObject.Find("Player") != null)
                    direction = /*bulletInfo.m_bullettargetDiection*/GameObject.Find("Player").transform.position - this.transform.position;
                rb.AddForce(direction * bulletInfo.m_bulletSpeed, ForceMode.Impulse);
                // rb.velocity = bullet.transform.up * bulletInfo.m_bulletSpeed;
                yield return new WaitForSeconds(bulletInfo.m_bulletShootTime);
                //  m_tempCnt++;
                bulletInfo.m_oneTimeSpawn = false;
            }
        }
    }

    void Update()
    {
        StartCoroutine(Shoot());
    }
}
