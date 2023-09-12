using Params;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private const int MAX_ROOM_POS_COUNT = 15;

    public static StageManager Instance;
    public GameObject objLoadingPanel;
    public Image imgLoadSliderImage;
    private StageParams.STAGE_TYPE _stCurrentStageType = StageParams.STAGE_TYPE.NONE;
    public delegate bool EpisodeBtnClickedDelegate(StageParams.STAGE_TYPE staygeType, GameObject target = null);
    public static event EpisodeBtnClickedDelegate EpisodeBtnClicked;
    public GameObject[] Charactors;
    //임시로 넣어 놓은 플레이어
    public GameObject player;

    public void InitializeStage(StageParams.STAGE_TYPE type, GameObject player)
    {
        _stCurrentStageType = type;
        //패널로 로딩창 -> 이니셜라이즈 coroutine으로 작성 종료시 로딩창 클로즈
        EpisodeBtnClicked(_stCurrentStageType, player);

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateStageFactory()
    {
        string path = FolderPath.PREFABS_STAGE_ROOM + PrefabName.STR_ROOM_PREFAB;
        if (GameManager.instance != null)
        {
            if (GameManager.instance.objectFactory.roomFactory.listPool.Count <= 0)
            {
                GameManager.instance.objectFactory.roomFactory.CreateFactory(path, MAX_ROOM_POS_COUNT);
            }
            else if (GameManager.instance.objectFactory.roomFactory.listPool.Count > 0
                && GameManager.instance.objectFactory.roomFactory.listPool.Count < MAX_ROOM_POS_COUNT)
            {
                int nFactoryCount = GameManager.instance.objectFactory.roomFactory.listPool.Count;
                GameObject roomPrefab = Resources.Load<GameObject>(path);
                GameManager.instance.objectFactory.roomFactory.CreateObject(roomPrefab, MAX_ROOM_POS_COUNT - nFactoryCount);
            }
        }
    }

    private void Start()
    {
        print(GameManager.instance.stageType.ToString());
        //게임메니저에서 데이터 받아오기
        Charactors = GameManager.instance.arrCurCharacters;
        player = Charactors[0];
        player.SetActive(true);
        //Audio 변경해야함
        AudioManager.instance.PlayBackgroundSound(GetComponent<AudioSource>(), AudioName.STR_MAIN_BACKGROUND);
        CreateStageFactory();
        InitializeStage(GameManager.instance.stageType, player);
        Debug.Log(GameManager.instance.stageType);
    }





}
