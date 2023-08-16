using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class field2 : MonoBehaviour
{
    public Transform[] monsterSpawnPoints;
    public GameObject monsterPrefab;
    public int monsterCount = 5;

    private bool test = false;

    void OnTriggerEnter(Collider other)
    {
        if (!test)
        {
            test = true;
            // 몬스터 개수는 정해져 있되 지정된 위치 중 랜덤위치 생성
            for (int i = 0; i < monsterCount; i++)
            {
                int random = Random.Range(0, monsterSpawnPoints.Length);
               Instantiate(monsterPrefab, monsterSpawnPoints[random].transform.position, transform.rotation);
            }
        }
    }
}

