using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public GameObject m_enemyType1, m_enemyTyp2, m_enemyType3,m_enemyType4, m_bossEnenmy;
    public GameObject m_quadDraticPth, m_linearPath1, m_linearpath2, m_linearPath3, m_linearPth4,m_linearPath5;
    public struct EnemyBehaviourStruct
    {
        public GameObject Enemy;
        public GameObject PathToFollow;
        public int Hits;
    }
}
