using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
//using ItemParameter;
public class ItemDatamanager : MonoBehaviour
{//제이슨 파일 가져와서 배열로
    public enum ITEM_TYPE
    {
        PROFESSIONALRMAL,
        EQUIPMENT,
        GEMSTONE,
        MATERIAL
    }

    public static readonly ItemDatamanager instance = new ItemDatamanager();
    string _strInvenItemPath;//경로
    string HaveInvenItem;//파일이름   
    public GameObject ItemPre;
    public ProfessionalData[] ProfessionalDatas;//0~
    public EquipData[] EquipDatas;//100~
    public GemStoneData[] GemStoneDatas;//200~
    public MaterialData[] MaterialDatas;//300~


    public UiCellView cellView;
    Dictionary<string, string> InItem = new Dictionary<string, string>();
    List<string> ItemId = new List<string>();//존재하는 아이템 아이디 리스트
    List<string> AllItemId = new List<string>();//모든 아이템 아이디리스트
    List<UiCellView> TotalItems = new List<UiCellView>();//장비 프리팹 리스트
    List<List<GameObject>> Items = new List<List<GameObject>>();
    //List<UiCellView> ProI = new List<UiCellView>();
    //List<UiCellView> EquipI = new List<UiCellView>();
    //List<UiCellView> Gem = new List<UiCellView>();
    //List<UiCellView> Mate = new List<UiCellView>();


    //public void Setup()
    //{

    //    for (int i = 0; i < System.Enum.GetValues(typeof(ITEM_TYPE)).Length; i++)
    //    {
    //        Items.Add(new List<UiCellView>());
    //    }

    //    for ()
    //    {
    //        if (i > 400)
    //        {
    //            Items[(int)ITEM_TYPE.NORMAL].Add();
    //        }
    //        else if ()
    //        {
    //            Items[(int)ITEM_TYPE.CLOSE].Add();

    //        }
    //        else
    //        {
    //            Items[(int)ITEM_TYPE.JUALY].Add();

    //        }
    //    }
    // }


    private void Start()
    {

        _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
        HaveInvenItem = FileName.STR_JSON_INVEN_ITEMS;//제이슨 파일 만들때 컨버터에 딕셔너리확인
        InItem = GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem);
        InitInven();
        Debug.Log(GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem));
        CreateAll();


    }
    public void InitInven()
    {

        if (GameManager.instance.CheckExist(_strInvenItemPath, HaveInvenItem))
        {//있을때
            LoadInvenData();
        }
        //없을때
        else
            WriteData();//파일 만들기
                        //파일에 모든 장비 갯수0개로 쓰기 함수 따로

    }
    public void LoadInvenData()
    {


        foreach (string key in InItem.Keys)//배열의 첫 값이 키
        {
            if (int.Parse(InItem[key]) != 0)
                ItemId.Add(key);//>>아이디와 스크립터블의 아이디가 같으면 슬롯에 정보주기

        }
    }
    public void CreateAll()
    {
        for (int j = 0; j < System.Enum.GetValues(typeof(ITEM_TYPE)).Length; j++)
        {
            Items.Add(new List<GameObject>());
        }
        foreach (string key in InItem.Keys)
            if (InItem[key] != null)
            {
                AllItemId.Add(key);
            }

        int materialIdx = 0;
        int GemStoneIdx = 0;
        int EquipIdx = 0;
        int ProfessionalIdx = 0;

        foreach (string key in AllItemId)
        {
            if (int.Parse(key) >= 300)
            {
                // for (int i = 0; i < MaterialDatas.Length; i++)
                if (int.Parse(key) == MaterialDatas[materialIdx].fId)
                {
                    var data = MaterialDatas[materialIdx];
                    GameObject Item = (GameObject)Instantiate(ItemPre);
                    Item.GetComponent<UiCellView>().SetUp(data);
                    //Item[(int)ITEM_TYPE.PROFESSIONALRMAL].
                    Items[(int)ITEM_TYPE.MATERIAL].Add(Item);
                    Debug.Log(Items[(int)ITEM_TYPE.MATERIAL].Count);
                }
                materialIdx++;
            }
            else if (int.Parse(key) >= 200)
            {
                //for (int i = 0; i < GemStoneDatas.Length; i++)
                if (int.Parse(key) == GemStoneDatas[GemStoneIdx].fId)
                {
                    var data = GemStoneDatas[GemStoneIdx];
                    GameObject Item = (GameObject)Instantiate(ItemPre);
                    Item.GetComponent<UiCellView>().SetUp(data);
                    //Item[(int)ITEM_TYPE.PROFESSIONALRMAL].
                    Items[(int)ITEM_TYPE.GEMSTONE].Add(Item);
                    //Debug.Log(Items[(int)ITEM_TYPE.GEMSTONE].Count);
                }
                GemStoneIdx++;
            }
            else if (int.Parse(key) >= 100)
            {
                // for (int i = 0; i < EquipDatas.Length; i++)
                if (int.Parse(key) == EquipDatas[EquipIdx].fId)
                {
                    var data = EquipDatas[EquipIdx];
                    GameObject Item = (GameObject)Instantiate(ItemPre);
                    Item.GetComponent<UiCellView>().SetUp(data);
                    //Item[(int)ITEM_TYPE.PROFESSIONALRMAL].
                    Items[(int)ITEM_TYPE.EQUIPMENT].Add(Item);
                }
                EquipIdx++;

            }
            else
            {
                // for(int i = 0; i < ProfessionalDatas.Length; i++)
                if (int.Parse(key) == ProfessionalDatas[ProfessionalIdx].fId)
                {
                    var data = ProfessionalDatas[ProfessionalIdx];
                    GameObject Item = (GameObject)Instantiate(ItemPre);
                    Item.GetComponent<UiCellView>().SetUp(data);
                    //Item[(int)ITEM_TYPE.PROFESSIONALRMAL].
                    Items[(int)ITEM_TYPE.PROFESSIONALRMAL].Add(Item);
                }
                ProfessionalIdx++;

            }
        }

    }
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
    public void DisplayEmpty()
    {//슬롯에 빈칸 표시

    }
    public void ToSolt()
    {



    }
    public void WriteData()
    {//초기 인벤토리 모든 장비 0
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();

        //for (int i = 0; i < ProfessionalDatas.Length; i++)
        //{
        //    dictTemp.Add(ProfessionalDatas[i].fId, ProfessionalDatas[i].);
        //}
        //for (int i = 0; i < EquipDatas.Length; i++)
        //{

        //}
        //for (int i = 0; i < GemStoneDatas.Length; i++)
        //{

        //}
        //for (int i = 0; i < MaterialDatas.Length; i++)
        //{

        //}
        dictTemp.Add("0", "0");
        dictTemp.Add("1", "0");
        dictTemp.Add("2", "0");
        dictTemp.Add("100", "0");
        dictTemp.Add("101", "0");
        dictTemp.Add("102", "0");
        dictTemp.Add("103", "0");
        dictTemp.Add("200", "0");
        dictTemp.Add("201", "0");
        dictTemp.Add("202", "0");
        dictTemp.Add("203", "0");
        dictTemp.Add("300", "0");
        dictTemp.Add("301", "0");
        dictTemp.Add("302", "0");
        dictTemp.Add("303", "0");

        GameManager.instance.DataWrite(_strInvenItemPath + HaveInvenItem, dictTemp);
    }
    public void LoadEquipData()
    {
        //Debug.Log(equip.fId);
        //TextAsset asset= Resources.Load<TextAsset>("InventoryTest/Equip_Data");
        //string json = asset.text;
        ////역직렬화
        //EquipData[] arr= JsonConvert.DeserializeObject<EquipData[]>(json);
        ////foreach for 돌리며 drc에 추가

        ////this.dicEquipData= arr.ToDictionary(x => x.EquipParams.fId);
        //Debug.Log("load");
        //Debug.LogFormat("item data count:{0}",this.dicEquipData.Count);
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
