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
    
    public bool Initialize(GameObject positionObjects, object roomType, GameObject player, bool bUseBoss)
    {
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        roomParam.roomType = (GimmickRoomParams.ROOM_TYPE)roomType;
        this.bUseBoss = bUseBoss;
        this.player = player;
        Debug.Log("이니셜 라이즈 시작");
        SetObjectPosition();
        return false;
    }

    public void ClearRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
        gimmick.SetActive(false);
    }

    public bool CreateObjectFactory(string objectName)
    {
        return false;
    }

    public void DisableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
        gimmick.SetActive(false);
    }

    public void EnableRoom()
    {
        GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
        gimmick.SetActive(true);
    }
    

    public void SetObjectPosition()
    {
        //if (roomParam.nMaxEventCount > 1)
        //{
        Debug.Log("셋 오브젝트 포지션 시작");

        List<GameObject> gimmicks = GameManager.instance.objectFactory.GimmickRoomFactory.listPool;
        Debug.Log(gimmicks);


        Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
        string GimmickType = roomParam.roomType.ToString();
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
            //    GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
            //    Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
            //    Params.GimmickRoomParams.ROOM_TYPE GimmickType = roomParam.roomType;
            //    gimmick.transform.position = GimmickPos.position;
            //    gimmick.transform.rotation = GimmickPos.rotation;
            //    //gimmick.SetActive(false);
            //}
    }

}
