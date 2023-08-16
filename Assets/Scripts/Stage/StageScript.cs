using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using RandomL;

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

    FactoryManager factoryManager;
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
    bool Initialize(StageParams.STAGE_TYPE staygeType)
    {
        try
        {
            factoryManager = new FactoryManager();
            //sParams = lParamsSimulator.LoadParams();
            string path = "ScriptableObjects\\StageDefaultData\\StageScriptableData" + ((int)staygeType).ToString("D2");
            StageScriptableData stageData = (StageScriptableData)Resources.Load(path);
            if (stageData == null)
                return false;

            if (!stageData.ChapterTypeCompare(staygeType))
                return false;

            stageData.DataInit(sParams);

            //및의 부분을 분리할지 고민중
            _nMaxRoomCount = sParams.nMaxRoomCount;
            _nMinRoomCount = _nMaxRoomCount - 2;
            _nSetRoomCount = Random.Range(_nMinRoomCount, _nMaxRoomCount);
            CreateStage(sParams.typeChapter);

            return true;
        }
        catch
        {
            return false;
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
            Object[] roomPosData = Resources.LoadAll("ScriptableObjects\\RoomPosition\\Episode" + ((int)stStageType).ToString());
            RoomPosInit(roomPosData);

            objRoomPositions = new GameObject[_nSetRoomCount];
            List<int> lstIdxList = RandomList.Inistance.NotDuplicatedRandomList(0, _nMaxRoomCount, _nSetRoomCount );

            for (int i = 0; i < objRoomPositions.Length; i++)
            {
                objRoomPositions[i] = factoryManager.GetObject();
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
        catch(System.Exception e)
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
