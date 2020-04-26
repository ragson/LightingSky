//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

using System.Collections;
using UnityEngine;

public class Level2Script : LevelScript,ILevel
{
    //moveobject method call Enemy war waves diffeent positions .
    public IEnumerator MoveObject()
    {
        StartCoroutine(MoveQudaratic());
        yield return new WaitUntil(() => m_1stWaveObjinfo.m_tempObjCnt == 6);
        StartCoroutine(StatObjectRandomly());
        yield return new WaitUntil(() => objcnt == m_2ndWaveObjInfo.m_movingObjsCnt);
        StartCoroutine(MoveLerp(m_3rdWaveObjInfo));
        StartCoroutine(MoveLerp(m_4thWaveObjInfo));
        yield return new WaitUntil(() => Globals.enemy4List.Count == 0);
        StartCoroutine(MoveLerp(m_5thWaveObjInfo));
    }
}
