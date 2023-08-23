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
    public delegate bool EpisodeBtnClickedDelegate(StageParams.STAGE_TYPE staygeType, GameObject target = null);
    public static event EpisodeBtnClickedDelegate EpisodeBtnClicked;
    //�ӽ÷� �־� ���� �÷��̾�
    public GameObject target;

    public void InitializeStage(StageParams.STAGE_TYPE type, GameObject player)
    {
        _stCurrentStageType = type;
        //�гη� �ε�â -> �̴ϼȶ����� coroutine���� �ۼ� ����� �ε�â Ŭ����
        EpisodeBtnClicked(_stCurrentStageType, null);

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
        //���Ӹ޴������� ������ �޾ƿ���
        InitializeStage(StageParams.STAGE_TYPE.CHAPTER1, target);


    }





}
