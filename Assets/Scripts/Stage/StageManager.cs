using Params;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public GameObject objLoadingPanel;
    public Image imgLoadSliderImage;
    private StageParams.STAGE_TYPE _stCurrentStageType = StageParams.STAGE_TYPE.NONE;
    public delegate bool EpisodeBtnClickedDelegate(StageParams.STAGE_TYPE staygeType);
    public event EpisodeBtnClickedDelegate EpisodeBtnClicked;

    public void InitializeStage(StageParams.STAGE_TYPE type)
    {
        _stCurrentStageType = type;
        //패널로 로딩창 -> 이니셜라이즈 coroutine으로 작성 종료시 로딩창 클로즈
        EpisodeBtnClicked(_stCurrentStageType);

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

    private void Start()
    {
        //게임메니저에서 데이터 받아오기
        InitializeStage(StageParams.STAGE_TYPE.CHAPTER1);


    }





}
