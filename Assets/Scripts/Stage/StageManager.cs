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
    public GameObject[] Charactors;
    //�ӽ÷� �־� ���� �÷��̾�
    public GameObject player;

    public void InitializeStage(StageParams.STAGE_TYPE type, GameObject player)
    {
        _stCurrentStageType = type;
        //�гη� �ε�â -> �̴ϼȶ����� coroutine���� �ۼ� ����� �ε�â Ŭ����
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

    private void Start()
    {
        print(GameManager.instance.stageType.ToString());
        //���Ӹ޴������� ������ �޾ƿ���
        Charactors = GameManager.instance.arrCurCharacters;
        player = Charactors[0];
        player.SetActive(true);
        //Audio �����ؾ���
        AudioManager.instance.PlayBackgroundSound(GetComponent<AudioSource>(),AudioName.STR_MAIN_BACKGROUND);
        InitializeStage(GameManager.instance.stageType, player);
    }





}
