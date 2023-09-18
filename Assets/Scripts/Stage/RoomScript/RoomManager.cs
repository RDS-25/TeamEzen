using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

// 1È¸¸¸ ½ÇÇà ½ÃÅ³ ¿¹Á¤
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
    //GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
    public bool Initialize(GameObject positionObjects, object roomType, GameObject player, bool bUseBoss)
    {
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        roomParam.roomType = (GimmickRoomParams.ROOM_TYPE)roomType;
        this.bUseBoss = bUseBoss;
        this.player = player;
        SetObjectPosition();
        return false;
    }

    public void ClearRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
        gimmick.SetActive(false);
    }

    public bool CreateObjectFactory(string objectName)
    {
        return false;
    }

    public void DisableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
        gimmick.SetActive(false);
    }

    public void EnableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
        gimmick.SetActive(true);
    }
    

    public void SetObjectPosition()
    {
        //if (roomParam.nMaxEventCount > 1)
        //{

        if (GameManager.instance.objectFactory.GimmickRoomFactory.listPool[0].GetComponent<GimmickScript>().GIMMICK_TYPE
            == GimmickRoomParams.ROOM_TYPE.STORE_ROOM)
        { 
        }
        //GameManager.instance.objectFactory.GimmickRoomFactory.listPool
        ////GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
        //Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
        //string GimmickType = roomParam.roomType.ToString().Split("_")[0]; //puzzle, trap, store, monster, boss
        //gimmick.transform.position = GimmickPos.position;
        //gimmick.transform.rotation = GimmickPos.rotation;
        ////string scPath = "Prefabs/Room/";
        ////GameObject Board = Resources.Load<GameObject>(scPath + GimmickType + "_BOARD");
        //print(gimmick.transform.position);
        //print(GimmickType);

        //Instantiate(Board, GimmickPos.position, GimmickPos.rotation);




        //}
        //else if (roomParam.nMaxEventCount > 0)
        //{
        //    GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
        //    Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
        //    Params.GimmickRoomParams.ROOM_TYPE GimmickType = roomParam.roomType;
        //    gimmick.transform.position = GimmickPos.position;
        //    gimmick.transform.rotation = GimmickPos.rotation;
        //    //gimmick.SetActive(false);
        //}
    }

}
