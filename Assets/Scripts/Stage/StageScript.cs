using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using RandomL;

public class LoadParamsSimulator
{
    public bool bClear = false;
    public int nMaxRoomCount = 5;
    public int nRoomcount = 0;
    public int nClearRoomCount = 0;
    public int nBossCount = 0;
    public string strStageName = "";
    public GameObject gPlayer = null;
    public StageParams.STAGE_TYPE type = StageParams.STAGE_TYPE.CHAPTER1;

    private static LoadParamsSimulator _instance;
    public static LoadParamsSimulator Instans
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LoadParamsSimulator();
            }

            return _instance;
        }
    }

    StageParams stageParams = new StageParams();
    private LoadParamsSimulator()
    {
        stageParams.nBossCount = this.nBossCount;
        stageParams.nMaxRoomCount = this.nMaxRoomCount;
        stageParams.bClear = this.bClear;
        stageParams.nClearRoomCount = this.nClearRoomCount;
        stageParams.nRoomcount = this.nRoomcount;
        stageParams.strStageName = this.strStageName;
        stageParams.gPlayer = this.gPlayer;
        stageParams.typeChapter = this.type;
    }

    public void SaveParams(StageParams value)
    {
        stageParams = value;
    }

    public StageParams LoadParams()
    {
        return stageParams;
    }
}

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
    public LoadParamsSimulator lParamsSimulator = LoadParamsSimulator.Instans;
    //펙토리 시뮬레이터 삭제예정
    private GameObject[] objRoomPositions;
    private bool _bCreateRoom = false;
    //RoomPositionData 저장 변수
    private RoomPositionData[] _rpdPositionData;

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
    bool Initialize(string strEpisodeName)
    {
        try
        {
            sParams = lParamsSimulator.LoadParams();
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
                objRoomPositions[i] = GameManager.Instance.objfRoomFectory.GetObject();
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
    private void OnDisable()
    {
        _bCreateRoom = false;
    }
    private void Start()
    {
        Initialize("Episode1");
    }
    //Event Delegate?
    //void StageClear()
    //{ 
    //}
    //void StageFailed()
    //{ 
    //}

}
