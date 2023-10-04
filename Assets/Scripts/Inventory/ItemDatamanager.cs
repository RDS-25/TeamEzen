using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using UnityEngine.UI;
using TMPro;
//using ItemParameter;
public class ItemDatamanager : MonoBehaviour
{//제이슨 파일 가져와서 배열로
    public GameObject Content;//컴포넌트 배치
    public GameObject ShowData;
    public SlotManager slotManager;    
    public static readonly ItemDatamanager instance = new ItemDatamanager();
    string _strInvenItemPath;//폴더경로    
    string SaveItemPath;//저장된 데이터파일 경로
    public GameObject ItemPre;
    public ProfessionalData[] ProfessionalDatas;//0~
    public EquipData[] EquipDatas;//100~
    public GemStoneData[] GemStoneDatas;//200~
    public MaterialData[] MaterialDatas;//300~

    Dictionary<string, string> PlusItem = new Dictionary<string, string>();//습득한 아이템정보
    Dictionary<string, string> SavedData = new Dictionary<string, string>();//저장된 정보
    List<string> ItemId = new List<string>();//현재 존재하는 아이템 아이디 리스트
    List<string> AllItemId = new List<string>();//모든 아이템 아이디리스트    
    List<List<GameObject>> Items = new List<List<GameObject>>();

    private void Start()
    {
        _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
        SaveItemPath = FileName.STR_JSON_INVEN_SAVE;
        //제이슨 파일 만들때 컨버터에 딕셔너리확인
                
        InitInven();
        CreateAll();
        
        GameManager.instance.objectFactory.ItemSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB,
                                                                        AllItemId.Count);
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // 인벤토리에 표시할 슬롯 이미지 (전체 개수만큼)  AllItemId
                            GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview 정보 담겨있는 리스트(전체 개수만큼)  
                            slotManager.SlotsInViewport,
                            SlotManager.OBJECT_TYPE.ITEM);
        for(int i = 0; i < GameManager.instance.objectFactory.ItemObjectFactory.listPool.Count; i++)
        {
            if (GameManager.instance.objectFactory.ItemSlotFactory.listPool[i].activeSelf)
                GameManager.instance.objectFactory.SetItemFactory.listPool.Add(GameManager.instance.objectFactory.ItemObjectFactory.listPool[i]);
        }
        // 슬롯 getchild 해서 텍스트에 개수 표시해주기>>슬롯에 표시된 아이템 순번과 정보담긴 프리팹의 순번이 같음
        CountSetUp();        
        GetComponent<SlotManager>().SetButtonClickedEvent();
        gameObject.SetActive(false);
    }
   
    public void InitInven()
    {
        
        if (GameManager.instance.CheckExist(_strInvenItemPath, SaveItemPath))
        {//있을때              
            LoadInvenData();
        }
        //없을때
        else
        {
            WriteData();
            LoadInvenData();
        }
    }    

    public void LoadInvenData()
    {
        SavedData = GameManager.instance.DataRead(_strInvenItemPath + SaveItemPath);
        foreach (string key in SavedData.Keys)//배열의 첫 값이 키
        {
            if (int.Parse(SavedData[key]) != 0)
                ItemId.Add(key);//>>아이디와 스크립터블의 아이디가 같으면 슬롯에 정보주기
        }
    }
    //public void ReLoadInven()
    //{
    //    LoadInvenData();
    //}
    public void CreateAll()
    {
        for (int j = 0; j < System.Enum.GetValues(typeof(ItemParameter.ItemType)).Length; j++)
        {
            Items.Add(new List<GameObject>());
        }

        foreach (string key in SavedData.Keys)
        {
            if (SavedData[key] != null)
            {
                AllItemId.Add(key);
            }
        }
        int poolIdx = 0;
        int idx = 0;
        foreach (string key in AllItemId)
        {
            int nKey = int.Parse(key);
            if (nKey / 100 != idx && nKey / 100 < System.Enum.GetValues(typeof(ItemParameter.ItemType)).Length)//아이템 종류 나눠주기
            {
                idx++;
            }
            //Item.GetComponentsInChildren<Image>()[0].gameObject.SetActive(false);//이미지 게임오브젝트 자체를 끈다
            GameObject Item = GameManager.instance.objectFactory.ItemObjectFactory.CreateObject(ItemPre);
            if (idx == (int)ItemParameter.ItemType.PROFESSIONAL)
            {
                var data = ProfessionalDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data);
            }
            else if (idx == (int)ItemParameter.ItemType.EQUIPMENT)
            {
                var data = EquipDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,PlusItem);
            }
            else if (idx == (int)ItemParameter.ItemType.GEMSTONE)
            {
                var data = GemStoneDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,PlusItem);
            }
            else if (idx == (int)ItemParameter.ItemType.MATERIAL)
            {
                var data = MaterialDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,PlusItem);
            }

            Items[idx].Add(Item);
            //Item.GetComponentsInChildren<Image>()[0].enabled = false; //컴포넌트를 끈다
            poolIdx++;
            if (poolIdx > GameManager.instance.objectFactory.ItemObjectFactory.listPool.Count)
                break;
        }
        #region foreach (string key in AllItemId)
        //foreach (string key in AllItemId)
        //{
        //    if (int.Parse(key) >= 300)
        //    {
        //        // for (int i = 0; i < MaterialDatas.Length; i++)
        //        if (int.Parse(key) == MaterialDatas[materialIdx].fId)
        //        {
        //            var data = MaterialDatas[materialIdx];
        //            GameObject Item = (GameObject)Instantiate(ItemPre, Content.transform);
        //            Item.GetComponent<UiCellView>().SetUp(data);
        //            Items[(int)ITEM_TYPE.MATERIAL].Add(Item);
        //            Item.GetComponentsInChildren<Image>()[0].enabled = false; //컴포넌트를 끈다
        //            //Item.GetComponentsInChildren<Image>()[0].gameObject.SetActive(false);//이미지 게임오브젝트 자체를 끈다
        //            //Item.transform.parent = transform;
        //            //Item.SetActive(false);

        //        }
        //        materialIdx++;
        //    }
        //    else if (int.Parse(key) >= 200)
        //    {
        //        //for (int i = 0; i < GemStoneDatas.Length; i++)
        //        if (int.Parse(key) == GemStoneDatas[GemStoneIdx].fId)
        //        {
        //            var data = GemStoneDatas[GemStoneIdx];
        //            GameObject Item = (GameObject)Instantiate(ItemPre, Content.transform);
        //            Item.GetComponent<UiCellView>().SetUp(data);
        //            Items[(int)ITEM_TYPE.GEMSTONE].Add(Item);
        //            Item.GetComponentsInChildren<Image>()[0].enabled = false;
        //            //Item.transform.parent = transform;
        //            //Item.SetActive(false);

        //        }
        //        GemStoneIdx++;
        //    }
        //    else if (int.Parse(key) >= 100)
        //    {
        //        // for (int i = 0; i < EquipDatas.Length; i++)
        //        if (int.Parse(key) == EquipDatas[EquipIdx].fId)
        //        {
        //            var data = EquipDatas[EquipIdx];
        //            GameObject Item = (GameObject)Instantiate(ItemPre, Content.transform);//content아래로
        //            Item.GetComponent<UiCellView>().SetUp(data);
        //            Items[(int)ITEM_TYPE.EQUIPMENT].Add(Item);
        //            Item.GetComponentsInChildren<Image>()[0].enabled = false;
        //            //Item.transform.parent = transform;
        //            //Item.SetActive(false);
        //            //Debug.Log(EquipIdx);
        //        }
        //        EquipIdx++;

        //    }
        //    else
        //    {
        //        // for(int i = 0; i < ProfessionalDatas.Length; i++)
        //        if (int.Parse(key) == ProfessionalDatas[ProfessionalIdx].fId)
        //        {
        //            var data = ProfessionalDatas[ProfessionalIdx];
        //            GameObject Item = (GameObject)Instantiate(ItemPre, Content.transform);
        //            Item.GetComponent<UiCellView>().SetUp(data);
        //            Items[(int)ITEM_TYPE.PROFESSIONALRMAL].Add(Item);
        //            Item.GetComponentsInChildren<Image>()[0].enabled = false;
        //            //Item.transform.parent = transform;
        //            //Item.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        //            //Item.SetActive(false);
        //        }
        //        ProfessionalIdx++;

        //    }
        //}
        #endregion
    }
    public void CountSetUp()
    {
        List<GameObject> Slot = GameManager.instance.objectFactory.ItemSlotFactory.listPool;
        List<GameObject> ItemData = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        Debug.Log(Slot.Count);
        for (int i = 0; i < Slot.Count; i++)
        {
            if (Slot[i].activeSelf && ItemData[i].GetComponent<UiCellView>().COUNT != 0)
            {
                if (ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.PROFESSIONAL)
                {
                    Slot[i].GetComponentInChildren<TMP_Text>().enabled = false;
                }
                else
                    Slot[i].GetComponentInChildren<TMP_Text>().text = "x"+ItemData[i].GetComponent<UiCellView>().COUNT.ToString();                
            }
        }
    }
   
    public void ChangeEquipTab()
    {//생성을 새로 한다  버튼 연동시키기
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // 인벤토리에 표시할 슬롯 이미지 (전체 개수만큼)  AllItemId
                            GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview 정보 담겨있는 리스트(전체 개수만큼)  
                            slotManager.SlotsInViewport,
                            SlotManager.OBJECT_TYPE.ITEM);
        List<GameObject> Slot = GameManager.instance.objectFactory.ItemSlotFactory.listPool;
        List<GameObject> ItemData = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].gameObject.SetActive(false);
            if (ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.EQUIPMENT&& ItemData[i].GetComponent<UiCellView>().COUNT > 0)
            {
                Slot[i].gameObject.SetActive(true);
            }
            else if(ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.PROFESSIONAL & ItemData[i].GetComponent<UiCellView>().COUNT > 0)
            {
                Slot[i].gameObject.SetActive(true);
            }
        }
    }
    public void ChangeGemStoneTab()
    {
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // 인벤토리에 표시할 슬롯 이미지 (전체 개수만큼)  AllItemId
                              GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview 정보 담겨있는 리스트(전체 개수만큼)  
                              slotManager.SlotsInViewport,
                              SlotManager.OBJECT_TYPE.ITEM);
        List<GameObject> Slot = GameManager.instance.objectFactory.ItemSlotFactory.listPool;
        List<GameObject> ItemData = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].gameObject.SetActive(false);            
            if (ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.GEMSTONE && ItemData[i].GetComponent<UiCellView>().COUNT>0)
            {                
                Slot[i].gameObject.SetActive(true);
            }
           
        }
    }
    public void ChangeMaterialTab()
    {
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // 인벤토리에 표시할 슬롯 이미지 (전체 개수만큼)  AllItemId
                              GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview 정보 담겨있는 리스트(전체 개수만큼)  
                              slotManager.SlotsInViewport,
                              SlotManager.OBJECT_TYPE.ITEM);
        List<GameObject> Slot = GameManager.instance.objectFactory.ItemSlotFactory.listPool;
        List<GameObject> ItemData = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].gameObject.SetActive(false);
            if (ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.MATERIAL && ItemData[i].GetComponent<UiCellView>().COUNT > 0)
            {
                Slot[i].gameObject.SetActive(true);
            }       
        }
    }
    public void ChangeTotalTab()
    {
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // 인벤토리에 표시할 슬롯 이미지 (전체 개수만큼)  AllItemId
                             GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview 정보 담겨있는 리스트(전체 개수만큼)  
                             slotManager.SlotsInViewport,
                             SlotManager.OBJECT_TYPE.ITEM);
    }

    #region CreatItem()
    //public void CreateItem()
    //{//처음0번대만 만들어지고 뒷번호들 안만들어짐? 안만들어짐
    //    foreach (string key in ItemId)
    //    {
    //        if (int.Parse(key) < 100)
    //        {
    //            for (int i = 0; i < ProfessionalDatas.Length; i++)
    //                if (int.Parse(key) == ProfessionalDatas[i].fId)
    //                {
    //                    var data = ProfessionalDatas[i];
    //                    GameObject Item = (GameObject)Instantiate(ItemPre);
    //                    Item.GetComponent<UiCellView>().SetUp(data);
    //                    //UiCellView itemPrefab = Instantiate(cellView) as UiCellView;
    //                    //itemPrefab.GetComponentInParent<Transform>().gameObject.SetActive(false);


    //                }
    //            Debug.Log("0:" + TotalItems.Count);
    //            Debug.Log("ddd");
    //        }
    //        if (int.Parse(key) < 200)
    //        {
    //            for (int i = 100; i < EquipDatas.Length; i++)
    //            {
    //                if (int.Parse(key) == EquipDatas[i].fId)
    //                {
    //                    var data = EquipDatas[i];
    //                    UiCellView Item = Instantiate(itemPrefab);
    //                    //Item.transform.SetParent(this.transform);
    //                    Item.SetUp(data);
    //                    TotalItems.Add(Item);
    //                    EquipI.Add(Item);
    //                }
    //            }
    //        }
    //        if (int.Parse(key) < 300)
    //        {
    //            for (int i = 200; i < GemStoneDatas.Length; i++)
    //            {
    //                if (int.Parse(key) == GemStoneDatas[i].fId)
    //                {
    //                    var data = GemStoneDatas[i];
    //                    UiCellView Item = Instantiate(itemPrefab);
    //                    //Item.transform.SetParent(this.transform);
    //                    Item.SetUp(data);
    //                    TotalItems.Add(Item);
    //                    Gem.Add(Item);
    //                }
    //            }
    //        }         

    //        if (int.Parse(key) < 400)
    //        {
    //            for (int i = 300; i < MaterialDatas.Length; i++)
    //            {
    //                if (int.Parse(key) == MaterialDatas[i].fId)
    //                {
    //                    //MaterialData materialData = MaterialDatas[i];
    //                    var data = MaterialDatas[i];
    //                    UiCellView Item = Instantiate(itemPrefab);
    //                    //Item.transform.SetParent(this.transform);
    //                    Item.SetUp(data);
    //                    TotalItems.Add(Item);
    //                    Mate.Add(Item);
    //                }
    //            }

    //        }
    //    }
    //    //Debug.Log(TotalItems.Count);
    //    //Debug.Log(Mate.Count);
    //    //Debug.Log(MaterialDatas.Length);
    //}

    #endregion
    public void AddItem(Dictionary<string ,int> additems)   //string key,int count)
    {//키가 같으면 밸류를 더해줌
        foreach (KeyValuePair<string,int> addItemData in additems)
        {
            if (SavedData.Keys.Contains<string>(addItemData.Key))
                SavedData[addItemData.Key] += addItemData.Value;
        }
        GameManager.instance.DataWrite(_strInvenItemPath + SaveItemPath, SavedData);
        LoadInvenData();
        //foreach (string key in additems.Keys)
        //{
        //    SavedData[key] += additems[key];
        //}

        //for(int i = 0; i < SavedData.Count; i++)
        //{
        //    SavedData[(int)i] += additems[i];
        //}
        //SavedData[] += additems;
        //GameManager.instance.DataWrite(_strInvenItemPath + SaveItemPath, SavedData);
    }
    //public void AddItem(string key, int count)   //string key,int count)
    //{//키가 같으면 밸류를 더해줌
    //    if(SavedData.Keys.Contains<string>(key))
    //        SavedData[key] += count;
    //    WriteData();
    //    //foreach (string key in additems.Keys)
    //    //{
    //    //    SavedData[key] += additems[key];
    //    //}

    //    //for(int i = 0; i < SavedData.Count; i++)
    //    //{
    //    //    SavedData[(int)i] += additems[i];
    //    //}
    //    //SavedData[] += additems;
    //    //GameManager.instance.DataWrite(_strInvenItemPath + SaveItemPath, SavedData);
    //}

    public void WriteData()
    {//초기 인벤토리 모든 장비 0
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        
                dictTemp.Add("0", "0");
                dictTemp.Add("1", "0");
                dictTemp.Add("2", "0");
                dictTemp.Add("100", "0");
                dictTemp.Add("101", "0");
                dictTemp.Add("102", "0");
                dictTemp.Add("103", "0");
                dictTemp.Add("104", "0");
                dictTemp.Add("105", "0");
                dictTemp.Add("106", "0");
                dictTemp.Add("107", "0");
                dictTemp.Add("108", "0");
                dictTemp.Add("200", "0");
                dictTemp.Add("201", "0");
                dictTemp.Add("202", "0");
                dictTemp.Add("203", "0");
                dictTemp.Add("204", "0");
                dictTemp.Add("205", "0");
                dictTemp.Add("206", "0");
                dictTemp.Add("207", "0");
                dictTemp.Add("208", "0");
                dictTemp.Add("209", "0");
                dictTemp.Add("210", "0");
                dictTemp.Add("211", "0");
                dictTemp.Add("300", "0");
                dictTemp.Add("301", "0");
                dictTemp.Add("302", "0");
        GameManager.instance.DataWrite(_strInvenItemPath + SaveItemPath, dictTemp);

    }
   
    
      
    
    public EquipData GetIEquipData(float fId)
    {
        //if (this.dicEquipData.ContainsKey(fId))
        //{
        //    return this.dicEquipData[fId];
        //}
        //Debug.LogFormat("key({0}) not found.", fId);
        return null;
    }

}
//public void Haveitem()
//{
//    for (int i = 0; i < Content.transform.childCount; i++)
//    {
//        GameObject objSlot = Content.transform.GetChild(i).gameObject;
//        if (ItemId.Contains(objSlot.GetComponent<UiCellView>().ID.ToString()) == true)
//        {
//            objSlot.GetComponentInChildren<Image>().enabled = true;
//        }
//    }
//}