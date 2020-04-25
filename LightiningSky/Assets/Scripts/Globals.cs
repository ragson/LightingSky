using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals m_globals;
    public static int EnemyDestroyCnt;
    public static int Enemy4DstrCnt;
    public static int bosslesslevedstryCnt;

    private void Awake()
    {
        m_globals = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Physics.IgnoreLayerCollision(8, 8);//collision ignorre between enemytypes
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(9, 10);
        Physics.IgnoreLayerCollision(9, 9);
    }
}
