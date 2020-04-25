using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScipt : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (!collision.collider.name.Contains("bullet"))
        {
            if (collision.collider.name.Contains("Enemy4"))
            {
                Globals.Enemy4DstrCnt++;
            }

            if (collision.collider.name.Contains("BossEnemyHolder"))
            {
                Globals.bosslesslevedstryCnt++;
            }
                Destroy(this.gameObject);
            //Debug.Log(collision.collider.name);
        }
    }
}
