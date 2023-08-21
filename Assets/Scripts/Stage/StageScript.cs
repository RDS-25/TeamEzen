using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using RandomL;

public class StageScript : MonoBehaviour
{
    //��� ���� �� ����
    private int _nMaxRoomCount = 0;
    //���� �� �ִ� ��ͷ��� �ּ� ����
    private int _nMinRoomCount = 0;
    private int _nSetRoomCount = 0;
    //�������� �Ķ����
    private StageParams sParams = new StageParams();
    //�ùķ����� ���� ����
    private GameObject[] objRoomPositions;
    private bool _bCreateRoom = false;
    //RoomPositionData ���� ����
    private RoomPositionData[] _rpdPositionData;

    FactoryManager factoryManager;
    //�� ������ ����
    bool RoomPosInit(object[] objRoomDataArray)
    {
        try
        {
            _rpdPositionData = new RoomPositionData[objRoomDataArray.Length];

            for (int cnt = 0; cnt < _rpdPositionData.Length; cnt++)
            {
                _rpdPositionData[cnt] = (RoomPositionData)objRoomDataArray[cnt];
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    //�ʱ�ȭ �Լ�
    bool Initialize(StageParams.STAGE_TYPE staygeType)
    {
        try
        {
            factoryManager = new FactoryManager();
            //sParams = lParamsSimulator.LoadParams();
            string path = "ScriptableObjects\\StageDefaultData\\StageScriptableData" + ((int)staygeType).ToString("D2");
            StageScriptableData stageData = Resources.Load<StageScriptableData>(path);

            if (stageData == null)
                return false;

            if (!stageData.ChapterTypeCompare(staygeType))
                return false;

            stageData.DataInit(sParams);

            //���� �κ��� �и����� �����
            _nMaxRoomCount = sParams.nMaxRoomCount;
            _nMinRoomCount = _nMaxRoomCount - 2;
            _nSetRoomCount = Random.Range(_nMinRoomCount, _nMaxRoomCount);

            //���丮�� �����ϴ� �� �� üũ�Ͽ� �ʿ��� Max������ ������� Object�߰�
            // if(GameManager.instance.roomFactory.)

            CreateStage(sParams.typeChapter);
            SetRoomType();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public GimmickRoomParams.ROOM_TYPE RoomType(int value)
    {
        GimmickRoomParams.ROOM_TYPE res = GimmickRoomParams.ROOM_TYPE.NONE;
        if (value > 80)
        {
            res = GimmickRoomParams.ROOM_TYPE.PUZZLE_ROOM;
        }
        else if (value > 20)
        {
            res = GimmickRoomParams.ROOM_TYPE.MONSTER_ROOM;
        }
        else
        {
            res = GimmickRoomParams.ROOM_TYPE.TRAP_ROOM;
        }

        return res;
    }

    public void SetRoomType()
    {
        List<int> listUseRoom = RandomList.Inistance.NotDuplicatedRandomList(0, objRoomPositions.Length, objRoomPositions.Length);

        //���� �� ��ġ
        //objRoomPositions[listUseRoom[0]].GetComponent<Room>().SetRoomType(GimmickRoomParams.ROOM_TYPE.BOSS_ROOM);
        listUseRoom.RemoveAt(0);
        //���� ��ġ
        if (Random.Range(0, 2) == 1 ? true : false)
        {
            //objRoomPositions[listUseRoom[0]].GetComponent<Room>().SetRoomType(GimmickRoomParams.ROOM_TYPE.STORE_ROOM);
            listUseRoom.RemoveAt(0);
        }
        //��� ��ġ
        foreach (int idx in listUseRoom)
        {
            //objRoomPositions[listUseRoom[0]].GetComponent<Room>().SetRoomType(RoomType(Random.Range(0, 100)));
        }
    }

    //Stage�� �� ��ġ�� ����
    public void CreateStage(StageParams.STAGE_TYPE stStageType)
    {
        try
        {
            if (_bCreateRoom)
                return;

            //�� ���丮 ���� �� ��ũ���ͺ� �����͸� ���� ������ ����
            _bCreateRoom = true;
            Object[] roomPosData = Resources.LoadAll("ScriptableObjects\\RoomPosition\\Episode" + ((int)stStageType).ToString());
            RoomPosInit(roomPosData);

            objRoomPositions = new GameObject[_nSetRoomCount];
            List<int> lstIdxList = RandomList.Inistance.NotDuplicatedRandomList(0, _nMaxRoomCount, _nSetRoomCount);

            for (int i = 0; i < objRoomPositions.Length; i++)
            {
                objRoomPositions[i] = GameManager.instance.stageFactory.roomFactory.GetObject();//factoryManager.GetObject();
                //�����ʿ�
                _rpdPositionData[lstIdxList[i]].SetRoomPosData(objRoomPositions[i]);
                for (int gimmick_idx = 0; gimmick_idx < objRoomPositions[i].transform.childCount; gimmick_idx++)
                {
                    _rpdPositionData[lstIdxList[i]].SetGimmickPosData(objRoomPositions[i].transform.GetChild(gimmick_idx).gameObject, gimmick_idx);
                }

                objRoomPositions[i].SetActive(true);
                objRoomPositions[i].GetComponent<SphereCollider>().enabled = true;
            }


        }
        catch (System.Exception e)
        {
            print(e.Message);
        }
    }
    private void OnEnable()
    {
        if (StageManager.Instance != null)
            StageManager.Instance.EpisodeBtnClicked += Initialize;
    }
    private void OnDisable()
    {
        _bCreateRoom = false;
        if (StageManager.Instance != null)
            StageManager.Instance.EpisodeBtnClicked -= Initialize;
    }

    //Event Delegate?
    //void StageClear()
    //{ 
    //}
    //void StageFailed()
    //{ 
    //}


}

