using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals m_globals;
    public static int EnemyDestroyCnt;
    public static List<GameObject> enemy4List;
    public static int bosslesslevedstryCnt;
    public static string Level;
    public static int m_coinscore;
    public static GameObject m_currentLvl;

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
        Physics.IgnoreLayerCollision(10, 10);
        Physics.IgnoreLayerCollision(10, 11);
        Physics.IgnoreLayerCollision(8, 12);
        Physics.IgnoreLayerCollision(9, 12);
        Physics.IgnoreLayerCollision(10, 12);
    }
}
