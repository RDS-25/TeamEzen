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
    //��� ���� �� ����
    private int _nMaxRoomCount = 0;
    //���� �� �ִ� ��ͷ��� �ּ� ����
    private int _nMinRoomCount = 0;
    private int _nSetRoomCount = 0;
    //�������� �Ķ����
    private StageParams sParams = new StageParams();
    //�ùķ����� ���� ����
    public LoadParamsSimulator lParamsSimulator = LoadParamsSimulator.Instans;
    //���丮 �ùķ����� ��������
    private GameObject[] objRoomPositions;
    private bool _bCreateRoom = false;
    //RoomPositionData ���� ����
    private RoomPositionData[] _rpdPositionData;

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
    bool Initialize(string strEpisodeName)
    {
        try
        {
            sParams = lParamsSimulator.LoadParams();
            //���� �κ��� �и����� �����
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
