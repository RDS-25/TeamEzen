using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

// 1ȸ�� ���� ��ų ����
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
    //GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
    public bool Initialize(GameObject positionObjects, object roomType, GameObject player, bool bUseBoss)
    {
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        roomParam.roomType = (GimmickRoomParams.ROOM_TYPE)roomType;
        this.bUseBoss = bUseBoss;
        print("Room Type : " + roomParam.roomType.ToString());
        this.player = player;
        SetObjectPosition();
        return false;
    }

    public void ClearRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
        gimmick.SetActive(false);
    }

    public bool CreateObjectFactory(string objectName)
    {
        return false;
    }

    public void DisableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
        gimmick.SetActive(false);
    }

    public void EnableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
        gimmick.SetActive(true);
    }
    

    public void SetObjectPosition()
    {
        if (roomParam.nMaxEventCount > 1)
        {
            List<int> idx = RandomL.RandomList.Inistance.NotDuplicatedRandomList(0, roomParam.trGroundPositions.Length, roomParam.nMaxEventCount);
            foreach (int id in idx)
            {
                GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
                Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
                gimmick.transform.position = GimmickPos.position;
                gimmick.transform.rotation = GimmickPos.rotation;
            }
        }
        else if (roomParam.nMaxEventCount > 0)
        {
            GameObject gimmick = new GameObject();//Fectory.GetObjct()���� ��� �̾ƿ���
            Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
            gimmick.transform.position = GimmickPos.position;
            gimmick.transform.rotation = GimmickPos.rotation;
            //gimmick.SetActive(false);
        }
        

    }

}
