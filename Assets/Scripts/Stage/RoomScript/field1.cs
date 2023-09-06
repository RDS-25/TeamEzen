using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class field1 : MonoBehaviour
{
    public Transform[] tMonsterSpawnPoints;
    public GameObject gMonsterPrefab;
    public int nMonsterCount = 5;

    RoomManager RoomParam = new RoomManager();

    private bool bState = false;

    void OnTriggerEnter(Collider other)
    {
        RoomParam.DisableRoom();
        if (!bState)
        {
            bState = true;
            // �ش� ��ġ�� 5���� ��ȯ
            for (int i = 0; i < nMonsterCount; i++)
            {
                for (int j = 0; j < tMonsterSpawnPoints.Length; j++)
                {
                    Instantiate(gMonsterPrefab, tMonsterSpawnPoints[j].transform.position, transform.rotation);
                }
            }
        }
    }
}

