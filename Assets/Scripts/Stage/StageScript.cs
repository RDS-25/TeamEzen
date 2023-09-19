using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using RandomL;

//보스포털주는형식으로 변경
//보스룸제작

public class StageScript : MonoBehaviour
{
    //기믹 룸의 총 갯수
    private int _nMaxRoomCount = 0;
    //만들 수 있는 기믹룸의 최소 갯수
    private int _nMinRoomCount = 0;
    private int _nSetRoomCount = 0;
    //스테이지 파라미터
    private StageParams sParams = new StageParams();
    //시뮬레이터 삭제 예정
    private GameObject[] objRoomPositions;
    private bool _bCreateRoom = false;
    //RoomPositionData 저장 변수
    private RoomPositionData[] _rpdPositionData;
    [SerializeField]
    Transform trStartPosition;
    //룸 포지션 셋팅
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

    //초기화 함수
    bool Initialize(StageParams.STAGE_TYPE staygeType, GameObject target = null)
    {
        try
        {
            //sParams = lParamsSimulator.LoadParams();
            string path = "ScriptableObjects\\StageDefaultData\\StageScriptableData" + ((int)staygeType).ToString("D2");
            StageScriptableData stageData = Resources.Load<StageScriptableData>(path);

            if (stageData == null)
                return false;

            if (!stageData.ChapterTypeCompare(staygeType))
                return false;

            stageData.DataInit(sParams);

            //및의 부분을 분리할지 고민중
            _nMaxRoomCount = sParams.nMaxRoomCount;
            _nMinRoomCount = _nMaxRoomCount - 2;
            _nSetRoomCount = Random.Range(_nMinRoomCount, _nMaxRoomCount);

            //펙토리에 존재하는 룸 수 체크하여 필요한 Max값보다 작은경우 Object추가
            // if(GameManager.instance.roomFactory.)

            CreateStage(sParams.typeChapter);
            //SetRoomType();

            if (target != null)
            {
                sParams.gPlayer = target;
                sParams.gPlayer.transform.position = trStartPosition.position;
            }

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
        List<int> listUseRoomIdx = RandomList.Inistance.NotDuplicatedRandomList(0, objRoomPositions.Length, objRoomPositions.Length);
        int nBossRoomIdx = listUseRoomIdx[Random.Range(0, listUseRoomIdx.Count)];
        print("Boss Idx : " + nBossRoomIdx);
        //상점 배치
        if (Random.Range(0, 2) == 1 ? true : false)
        {
            int idx = listUseRoomIdx[0];
            listUseRoomIdx.RemoveAt(0);
            
            if (idx == nBossRoomIdx)
                objRoomPositions[idx].GetComponent<RoomManager>().Initialize(objRoomPositions[idx],GimmickRoomParams.ROOM_TYPE.STORE_ROOM,StageManager.Instance.player,true);
            else
                objRoomPositions[idx].GetComponent<RoomManager>().Initialize(objRoomPositions[idx], GimmickRoomParams.ROOM_TYPE.STORE_ROOM, StageManager.Instance.player, false);
        }

        //기믹 배치
        foreach (int idx in listUseRoomIdx)
        {
            if (idx == nBossRoomIdx)
                objRoomPositions[idx].GetComponent<RoomManager>().Initialize(objRoomPositions[idx],RoomType(Random.Range(1,101)) , StageManager.Instance.player, true);
            else
                objRoomPositions[idx].GetComponent<RoomManager>().Initialize(objRoomPositions[idx], RoomType(Random.Range(1,101)), StageManager.Instance.player, false);
        }
    }

    //Stage의 룸 배치및 형성
    public void CreateStage(StageParams.STAGE_TYPE stStageType)
    {
        try
        {
            if (_bCreateRoom)
                return;

            //룸 펙토리 생성 후 스크립터블 데이터를 통해 포지션 설정
            _bCreateRoom = true;
            string roomPosDataPath = FolderPath.SCRIPTABLE_ROOM_POSITION + ((int)stStageType).ToString();
            Object[] roomPosData = Resources.LoadAll(roomPosDataPath);
            RoomPosInit(roomPosData);

            objRoomPositions = new GameObject[_nSetRoomCount];
            List<int> lstIdxList = RandomList.Inistance.NotDuplicatedRandomList(0, _nMaxRoomCount, _nSetRoomCount);

            for (int i = 0; i < objRoomPositions.Length; i++)
            {
                objRoomPositions[i] = GameManager.instance.objectFactory.roomFactory.GetObject();//factoryManager.GetObject();
                //수정필요
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
        StageManager.EpisodeBtnClicked += Initialize;
    }
    private void OnDisable()
    {
        _bCreateRoom = false;
        StageManager.EpisodeBtnClicked -= Initialize;
    }

    //Event Delegate?
    //void StageClear()
    //{ 
    //}
    //void StageFailed()
    //{ 
    //}


}

