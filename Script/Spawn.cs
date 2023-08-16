using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
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
            /*
            // 해당 위치에 5개씩 소환
            for (int i = 0; i < monsterCount; i++)
            {
                for (int j = 0; j < monsterSpawnPoints.Length; j++)
                {
                    Instantiate(monsterPrefab, monsterSpawnPoints[j].transform.position, transform.rotation);
                }
            }
            */
            /*
            // 몬스터 개수는 정해져 있되 지정된 위치 중 랜덤위치 생성
            for (int i = 0; i < monsterCount; i++)
            {
                int random = Random.Range(0, monsterSpawnPoints.Length);
               Instantiate(monsterPrefab, monsterSpawnPoints[random].transform.position, transform.rotation);
            }
            */

            /*
            // 필드 위 그냥 랜덤 위치 생성
            for (int i = 0; i < monsterCount; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
                Instantiate(monsterPrefab, transform.position + randomPosition, transform.rotation);
            }
            */
        }
    }
}

