using Params;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private const int MAX_ROOM_POS_COUNT = 15;

    public static StageManager Instance;
    private StageParams.STAGE_TYPE _stCurrentStageType = StageParams.STAGE_TYPE.NONE;
    public delegate bool EpisodeBtnClickedDelegate(StageParams.STAGE_TYPE staygeType, GameObject target = null);
    public static event EpisodeBtnClickedDelegate EpisodeBtnClicked;
    public GameObject[] Charactors;
    //임시로 넣어 놓은 플레이어
    public GameObject player;

    [SerializeField]
    private Transform trItemGridView;

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

	private void Update()
	{
        SwitchChar();

    }
	private bool IsDropItem(int minNum, int maxNum, float standardRate, List<int> rateList)
    {
        bool value = false;
        int idx = Random.Range(minNum, maxNum);

        if (rateList[idx] < standardRate)
            value = true;

        return value;

    }

    private List<ItemParameter.ItemType> AvailableItemType(StageParams.STAGE_TYPE stageType)
    {
        List<ItemParameter.ItemType> value = null;
        switch (stageType)
        {
            case StageParams.STAGE_TYPE.CHAPTER1:
                value = new List<ItemParameter.ItemType>() { ItemParameter.ItemType.MATERIAL, ItemParameter.ItemType.EQUIPMENT };
                break;
            case StageParams.STAGE_TYPE.CHAPTER2:
                value = new List<ItemParameter.ItemType>() { ItemParameter.ItemType.MATERIAL, ItemParameter.ItemType.EQUIPMENT };
                break;
            case StageParams.STAGE_TYPE.CHAPTER3:
                value = new List<ItemParameter.ItemType>() { ItemParameter.ItemType.MATERIAL, ItemParameter.ItemType.EQUIPMENT, ItemParameter.ItemType.GEMSTONE };
                break;
            case StageParams.STAGE_TYPE.CHAPTER4:
                value = new List<ItemParameter.ItemType>() { ItemParameter.ItemType.MATERIAL, ItemParameter.ItemType.EQUIPMENT, ItemParameter.ItemType.GEMSTONE };
                break;
            case StageParams.STAGE_TYPE.CHAPTER5:
                value = new List<ItemParameter.ItemType>() { ItemParameter.ItemType.MATERIAL, ItemParameter.ItemType.EQUIPMENT, ItemParameter.ItemType.GEMSTONE, ItemParameter.ItemType.PROFESSIONAL };
                break;
        }

        return value;
    }

    //
    //Stage UI작업 진행해야함
    //Event Delegate?
    public void StageClear()
    {
        string path = FolderPath.PARAMS_ITEM_COUNT + FileName.STR_JSON_INVEN_SAVE;
        int minNum = 0;
        int maxNum = 101;
        List<GameObject> itemList = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        List<int> itemDropRateList = RandomL.RandomList.Inistance.DuplicateRandomList(minNum, maxNum, 100);
        Dictionary<string, string> itemCountDic = GameManager.instance.DataRead(path);
        List<ItemParameter.ItemType> avilableItemTypeList = AvailableItemType(_stCurrentStageType);

        foreach (GameObject item in itemList)
        {

            UiCellView itemData = item.GetComponent<UiCellView>();
            bool bAddItem = IsDropItem(minNum, maxNum, item.GetComponent<UiCellView>().DROP_RATE, itemDropRateList);
            int nDropItemCount = 0;

            if (!avilableItemTypeList.Contains(itemData.TYPE)
                || !bAddItem)
                continue;

            if (itemData.TYPE == ItemParameter.ItemType.PROFESSIONAL)
            {
                if (itemData.COUNT < 1)
                {
                    nDropItemCount = 1;
                    itemCountDic[itemData.ID.ToString()] = nDropItemCount.ToString();
                }
                else
                    bAddItem = false;
            }
            else
            {
                int value = int.Parse(itemCountDic[itemData.ID.ToString()]);
                nDropItemCount = Random.Range(1, 6);
                value += nDropItemCount;
                itemCountDic[itemData.ID.ToString()] = value.ToString();
            }

            if (bAddItem)
            {
                GameObject slot = Resources.Load<GameObject>(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB);
                Instantiate(slot, trItemGridView);
                slot.GetComponent<Image>().sprite = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE_ITEM_ICON+itemData.IMAGE_PATH);
                slot.GetComponentInChildren<TMPro.TextMeshPro>().text = nDropItemCount.ToString();
                slot.SetActive(true);
            }

        }
        GameManager.instance.DataWrite(path, itemCountDic);
    }

    void SwitchChar() {

        if (Input.GetKey(KeyCode.Alpha1))
        {

            Charactors[0].SetActive(true);
            Charactors[0].transform.rotation = player.transform.rotation;
            Charactors[0].transform.position = player.transform.position;


            for (int i = 0; i < Charactors.Length; i++)
            {
                if (i != 0)
                {
                    Charactors[i].SetActive(false);
                }
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Charactors[1].SetActive(true);
            Charactors[2].transform.rotation = player.transform.rotation;
            Charactors[2].transform.position = player.transform.position;

            for (int i = 0; i < Charactors.Length; i++)
            {
                if (i != 1)
                {
                    Charactors[i].SetActive(false);
                }
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Charactors[2].SetActive(true);
            Charactors[2].transform.rotation = player.transform.rotation;
            Charactors[2].transform.position = player.transform.position;

            if (Charactors[2] != null)
            {
                Charactors[2].SetActive(true);
                for (int i = 0; i < Charactors.Length; i++)
                {
                    if (i != 2)
                    {
                        Charactors[i].SetActive(false);
                    }
                }
            }
        }
    }
}



