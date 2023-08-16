using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class field1 : MonoBehaviour
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
            // 해당 위치에 5개씩 소환
            for (int i = 0; i < monsterCount; i++)
            {
                for (int j = 0; j < monsterSpawnPoints.Length; j++)
                {
                    Instantiate(monsterPrefab, monsterSpawnPoints[j].transform.position, transform.rotation);
                }
            }
        }
    }
}

