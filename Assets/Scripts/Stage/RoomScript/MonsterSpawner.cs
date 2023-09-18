using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject Player;

    public int monsterCount = 5;
    public int playerRange = 10;
    private int nCount = 0;

    private bool bState = false;    
    void OnTriggerEnter(Collider other)
    {
        if (!bState)
        {
            bState = true;

            InvokeRepeating("MonsterSpawn", 2f, 1.0f);
        }
    }

    void MonsterSpawn()
    {
        // �ʵ� �� �׳� ���� ��ġ ����
        if (nCount < monsterCount) 
        {
            nCount++;
            Debug.Log("����");
            Vector3 randomPosition = new Vector3(Random.Range(-transform.lossyScale.x / 2, transform.lossyScale.x / 2), 0, Random.Range(-transform.lossyScale.z / 2, transform.lossyScale.z / 2));

            if (randomPosition.x > Player.transform.position.x + playerRange || randomPosition.x < Player.transform.position.x - playerRange || randomPosition.z > Player.transform.position.z + playerRange || randomPosition.z < Player.transform.position.z - playerRange)
            {
                Instantiate(monsterPrefab, transform.position + randomPosition, transform.rotation);
            }
            else
            {
                nCount--;
            }
        }
        else
        {
            Debug.Log("����");
            CancelInvoke("MonsterSpawn");
        }
    }
}
