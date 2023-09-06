using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class field3 : MonoBehaviour
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

            // 필드 위 그냥 랜덤 위치 생성
            for (int i = 0; i < monsterCount; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
                Instantiate(monsterPrefab, transform.position + randomPosition, transform.rotation);
            }
        }
    }
}

