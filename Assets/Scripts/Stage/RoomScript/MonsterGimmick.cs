using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGimmick : Gimmick
{
    public GameObject monsterPrefab;
    public GameObject Player;

    public int monsterCount = 5;
    public int playerRange = 10;
    private int nCount = 0;
    MonoBehaviour mb;
    private bool bState = false;

    public void InitializeGimmick(MonoBehaviour mb, GameObject a, GameObject b)
    {
        this.mb = mb;
        string prePath = "Prefabs/Room/";
        monsterPrefab = Resources.Load<GameObject>(prePath + "Monster");
        Player = GameObject.Find("Player");
        // GameObject 변수 받아오기
    }
    public void ActiveGimmick()
    {
        if (!bState)
        {
            bState = true;
            mb.StartCoroutine(MonsterSpawn());
        }
    }

    public void DiableGimmick()
    {

    }

    private IEnumerator MonsterSpawn()
    {
        yield return new WaitForSeconds(2.0f);

        if (nCount < monsterCount)
        {
            for (var i = nCount; i < monsterCount; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-mb.transform.lossyScale.x / 2, mb.transform.lossyScale.x / 2), 0, Random.Range(-mb.transform.lossyScale.z / 2, mb.transform.lossyScale.z / 2));

                if (randomPosition.x > Player.transform.position.x + playerRange || randomPosition.x < Player.transform.position.x - playerRange || randomPosition.z > Player.transform.position.z + playerRange || randomPosition.z < Player.transform.position.z - playerRange)
                {
                    //MonoBehaviour.Instantiate(monsterPrefab, mb.transform.position + randomPosition, mb.transform.rotation);
                    List<GameObject> monsterList = GameManager.instance.objectFactory.MonsterRoomFactory.listPool;
                    foreach (GameObject monster in monsterList)
                    {
                        monster.transform.position = mb.transform.position + randomPosition;
                        monster.transform.rotation = mb.transform.rotation;
                        monster.SetActive(true);
                    }
                }
                else
                {
                    nCount--;
                }
                yield return new WaitForSeconds(1.0f); 
            }
        }
    }
}
