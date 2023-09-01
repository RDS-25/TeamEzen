using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

// 1È¸¸¸ ½ÇÇà ½ÃÅ³ ¿¹Á¤
public class RoomManager : MonoBehaviour, DefaultRoom
{
    public static RoomManager Instance { get; private set; }
    //GimmickRoomParams roomParams = new GimmickRoomParams();
    GimmickRoomParams roomParam = new GimmickRoomParams();
    //GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â

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
    
    public bool Initialize(GameObject positionObjects, Object roomType, GameObject player)
    {
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        SetObjectPosition();
        return false;
    }

    public void SetObjectPosition()
    {
        if (roomParam.nMaxEventCount > 1)
        {
            List<int> idx = RandomL.RandomList.Inistance.NotDuplicatedRandomList(0, roomParam.trGroundPositions.Length, roomParam.nMaxEventCount);
            foreach (int id in idx)
            {
                GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
                Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
                gimmick.transform.position = GimmickPos.position;
                gimmick.transform.rotation = GimmickPos.rotation;
            }
        }
        else if (roomParam.nMaxEventCount > 0)
        {
            GameObject gimmick = new GameObject();//Fectory.GetObjct()¿¡¼­ ±â¹Í »Ì¾Æ¿À±â
            Transform GimmickPos = roomParam.trGroundPositions[Random.Range(0, roomParam.trGroundPositions.Length)];
            gimmick.transform.position = GimmickPos.position;
            gimmick.transform.rotation = GimmickPos.rotation;
            //gimmick.SetActive(false);
        }
        

    }
}
