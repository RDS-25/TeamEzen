using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGimmick : Gimmick
{
    public GameObject monsterPrefab;
    public GameObject Player;
    GameObject SpawnMonster;


    public int monsterCount = 5;
    public int playerRange = 10;
    MonoBehaviour mb;
    private bool bState = false;
    private bool bClearCheck = false;

    public void InitializeGimmick(MonoBehaviour mb, GameObject Stroe, GameObject StoreUi, GameObject TrapUi)
    {
        Debug.Log("tt");
        this.mb = mb;
        string prePath = "Prefabs/Room/";
        monsterPrefab = Resources.Load<GameObject>(prePath + "Monster");
        Player = GameObject.Find("Player");
        // GameObject 변수 받아오기
    }
    public void UpdateGimmick()
    {
        if (bState && bClearCheck)
        {
            if(mb.gameObject.transform.childCount == 0)
            {
                RoomManager.nClearCount++;
                bClearCheck = false;
            }
        }
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
        for (var i = 0; i < monsterCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-mb.transform.lossyScale.x / 2, mb.transform.lossyScale.x / 2), 0, Random.Range(-mb.transform.lossyScale.z / 2, mb.transform.lossyScale.z / 2));

            if (randomPosition.x > Player.transform.position.x + playerRange 
                || randomPosition.x < Player.transform.position.x - playerRange 
                || randomPosition.z > Player.transform.position.z + playerRange 
                || randomPosition.z < Player.transform.position.z - playerRange)
            {
                SpawnMonster = GameManager.instance.objectFactory.MeleeMonsterFactory.GetObject();
                //SpawnMonster = GameManager.instance.objectFactory.RangedMonsterFactory.GetObject();
                SpawnMonster.transform.position = mb.transform.position + randomPosition;
            }
            yield return new WaitForSeconds(1.0f);
        }
        bClearCheck = true;
    }
}
