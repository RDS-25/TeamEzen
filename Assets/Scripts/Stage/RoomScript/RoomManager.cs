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
    private int monsterMaxCount = 0;
    public static int nClearCount = 0;
    private int nGimmickCount = 0;
    GameObject Portal;
    GameObject PortalSpawn;
    public static Vector3[] vRoomPos = null;

    //GameObject gimmick = new GameObject();//Fectory.GetObjct()에서 기믹 뽑아오기
    GameObject gimmick;

    public bool Initialize(GameObject positionObjects, object roomType, GameObject player, bool bUseBoss)
    {
        Debug.Log("이니셜라이즈 실행");
        roomParam.trGroundPositions = positionObjects.GetComponentsInChildren<Transform>();
        roomParam.roomType = (GimmickRoomParams.ROOM_TYPE)roomType; // MONSTER_ROOM,PUZZLE_ROOM,TRAP_ROOM,STORE_ROOM
        this.bUseBoss = bUseBoss;
        this.player = player;
        SetObjectPosition();
        return false;
    }

    public void Start()
    {
        //Debug.Log("실행");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        //if (nClearCount >= nGimmickCount)
        {
            PortalSpawn.SetActive(true);
        }
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
        if(bUseBoss)
        {
            string prePath = "Prefabs/Room/";
            Portal = Resources.Load<GameObject>(prePath + "Portal");
            PortalSpawn = Instantiate(Portal, new Vector3(gimmick.transform.position.x,2, gimmick.transform.position.z), gimmick.transform.rotation);
            PortalSpawn.transform.parent = gimmick.transform;
        }
        gimmick.SetActive(true);
    }
    

    public void SetObjectPosition()
    {
        Debug.Log("셋 오브젝트 포지션 실행");
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
                    //vRoomPos[nGimmickCount] = GimmickPos.position;

                    gimmick = obj;
                    EnableRoom();
                    monsterMaxCount += obj.GetComponent<MonsterGimmick>().monsterCount;
                    break;
                }
            }
        }
        else
        {
            foreach (GameObject obj in gimmicks)
            {
                string gType = obj.name.Split("_")[0];
                if (gType == rType)
                {
                    if (obj.activeSelf == false)
                    {
                        obj.transform.position = GimmickPos.position;
                        obj.transform.rotation = GimmickPos.rotation;
                        //vRoomPos[nGimmickCount] = GimmickPos.position;

                        gimmick = obj;
                        EnableRoom();
                        break;
                    }
                }
            }
        }
        nGimmickCount++;
    }

    public void SetQuest(GimmickRoomParams.ROOM_TYPE roomType)
    {
        if (roomType == GimmickRoomParams.ROOM_TYPE.MONSTER_ROOM || roomType == GimmickRoomParams.ROOM_TYPE.BOSS_ROOM)
        {
            StageManager.Instance.qManager.InitQuest(QuestManager.QuestType.MONSTER, monsterMaxCount);
        }
        else if (roomType == GimmickRoomParams.ROOM_TYPE.STORE_ROOM)
        {
            return;
        }
        else
        { 
        }
    }
}
