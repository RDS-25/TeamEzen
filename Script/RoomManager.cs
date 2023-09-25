using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

// 1회만 실행 시킬 예정
public class RoomManager : MonoBehaviour, DefaultRoom
{
    [SerializeField]
    private bool bUseBoss = false;
    [SerializeField]
    private GameObject player;
    //public static RoomManager Instance { get; private set; }
    //GimmickRoomParams roomParams = new GimmickRoomParams();
    [SerializeField]
    private GimmickRoomParams roomParam = new GimmickRoomParams();

    //GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
    GameObject gimmick;

    public bool Initialize(GameObject positionObjects, object roomType, GameObject player, bool bUseBoss)
    {
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        roomParam.roomType = (GimmickRoomParams.ROOM_TYPE)roomType; // MONSTER_ROOM,PUZZLE_ROOM,TRAP_ROOM,STORE_ROOM
        this.bUseBoss = bUseBoss;
        this.player = player;
        SetObjectPosition();
        return false;
    }

    public void ClearRoom()
    {
        gimmick.SetActive(false);
    }

    public bool CreateObjectFactory(string objectName)
    {
        return false;
    }

    public void DisableRoom()
    {
        gimmick.SetActive(false);
    }

    public void EnableRoom()
    {
        gimmick.SetActive(true);
    }
    

    public void SetObjectPosition()
    {
        //if (roomParam.nMaxEventCount > 1)
        //{
        List<GameObject> gimmicks = GameManager.instance.objectFactory.GimmickRoomFactory.listPool;
        List<GameObject> monsters = GameManager.instance.objectFactory.MonsterRoomFactory.listPool;
        Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
        string rType = roomParam.roomType.ToString().Split("_")[0];
        if (rType == "MONSTER")
        {
            foreach (GameObject obj in monsters)
            {
                if (obj.activeSelf == false)
                {
                    obj.transform.position = GimmickPos.position;
                    obj.transform.rotation = GimmickPos.rotation;

                    gimmick = obj;
                    EnableRoom();
                    break;
                }
            }
        }
        else
        {
            // 문제
            foreach (GameObject obj in gimmicks)
            {
                string gType = obj.name.Split("_")[0];
                if (gType == rType)
                {
                    if (obj.activeSelf == false)
                    {
                        obj.transform.position = GimmickPos.position;
                        obj.transform.rotation = GimmickPos.rotation;

                        gimmick = obj;
                        EnableRoom();
                        break;
                    }
                }
            }
        }
    }

}
