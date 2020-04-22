using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour, ShootingInteface
{
    BulletInfo bulletInfo;

    public IEnumerator Shoot()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        bulletInfo = GetComponent<BulletInfo>();
    }

    //bool onetime;
    //GameObject bullet;
    //public void Shoot()
    //{

    //    if (!onetime)
    //    {
    //        bullet = Instantiate(bulletInfo.m_bulletPrfab,this.transform.position,Quaternion.Euler(0,0,0));
    //        bullet.transform.SetParent(bulletInfo.m_parent.transform);
    //        bullet.GetComponent<DestroyObject>().m_timeAfterDestroy = bulletInfo.m_timeAfterDestroy;

    //        onetime = true;
    //    }
    //    if (bullet != null&&onetime)
    //        bullet.transform.Translate(Vector3.down * Time.smoothDeltaTime*bulletInfo.Speed, Space.World);
       
    //}

    //void Update()
    //{
    //    Shoot();
    //}
}
