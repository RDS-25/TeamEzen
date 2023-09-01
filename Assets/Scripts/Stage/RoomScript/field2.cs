using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class field2 : MonoBehaviour
{
    public Transform[] tMonsterSpawnPoints;
    public GameObject gMonsterPrefab;
    public int nMonsterCount = 5;

    private bool bState = false;

    void OnTriggerEnter(Collider other)
    {
        if (!bState)
        {
            bState = true;
            // 몬스터 개수는 정해져 있되 지정된 위치 중 랜덤위치 생성
            for (int i = 0; i < nMonsterCount; i++)
            {
                int random = Random.Range(0, tMonsterSpawnPoints.Length);
               Instantiate(gMonsterPrefab, tMonsterSpawnPoints[random].transform.position, transform.rotation);
            }
        }
    }
}

