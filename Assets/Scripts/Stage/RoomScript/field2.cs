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
            // ���� ������ ������ �ֵ� ������ ��ġ �� ������ġ ����
            for (int i = 0; i < nMonsterCount; i++)
            {
                int random = Random.Range(0, tMonsterSpawnPoints.Length);
               Instantiate(gMonsterPrefab, tMonsterSpawnPoints[random].transform.position, transform.rotation);
            }
        }
    }
}

