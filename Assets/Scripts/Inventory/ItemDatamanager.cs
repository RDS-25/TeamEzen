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
{//���̽� ���� �����ͼ� �迭��
    public GameObject Content;//������Ʈ ��ġ
    public GameObject ShowData;
    public SlotManager slotManager;    
    public static readonly ItemDatamanager instance = new ItemDatamanager();
    string _strInvenItemPath;//���
    string HaveInvenItem;//�����̸�   
    public GameObject ItemPre;
    public ProfessionalData[] ProfessionalDatas;//0~
    public EquipData[] EquipDatas;//100~
    public GemStoneData[] GemStoneDatas;//200~
    public MaterialData[] MaterialDatas;//300~

    Dictionary<string, string> InItem = new Dictionary<string, string>();
    List<string> ItemId = new List<string>();//���� �����ϴ� ������ ���̵� ����Ʈ
    List<string> AllItemId = new List<string>();//��� ������ ���̵𸮽�Ʈ    
    List<List<GameObject>> Items = new List<List<GameObject>>();


    private void OnEnable()
    {
        SlotManager.OnButtonClick += OpenDataPan;
    }
    private void OnDisable()
    {
        SlotManager.OnButtonClick -= OpenDataPan;
    }
    private void Start()
    {
        _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
        HaveInvenItem = FileName.STR_JSON_INVEN_ITEMS;//���̽� ���� ���鶧 �����Ϳ� ��ųʸ�Ȯ��
        InItem = GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem);
        InitInven();
        CreateAll();
        
        GameManager.instance.objectFactory.ItemSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB,
                                                                        AllItemId.Count);
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // �κ��丮�� ǥ���� ���� �̹��� (��ü ������ŭ)  AllItemId
                            GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview ���� ����ִ� ����Ʈ(��ü ������ŭ)  
                            slotManager.SlotsInViewport,
                            SlotManager.OBJECT_TYPE.ITEM);

        // ���� getchild �ؼ� �ؽ�Ʈ�� ���� ǥ�����ֱ�>>���Կ� ǥ�õ� ������ ������ ������� �������� ������ ����
        CountSetUp();        
        GetComponent<SlotManager>().SetButtonClickedEvent();
    }
    public void InitInven()
    {

        if (GameManager.instance.CheckExist(_strInvenItemPath, HaveInvenItem))
        {//������
            LoadInvenData();
        }
        //������
        else
        {
            WriteData();//���� �����,���Ͽ� ��� ��� ����0���� ���� �Լ� ����
            LoadInvenData();
        }


    }

    public void LoadInvenData()
    {
        foreach (string key in InItem.Keys)//�迭�� ù ���� Ű
        {
            if (int.Parse(InItem[key]) != 0)
                ItemId.Add(key);//>>���̵�� ��ũ���ͺ��� ���̵� ������ ���Կ� �����ֱ�
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

        foreach (string key in InItem.Keys)
        {
            if (InItem[key] != null)
            {
                AllItemId.Add(key);
            }
        }
        int poolIdx = 0;
        int idx = 0;
        foreach (string key in AllItemId)
        {
            int nKey = int.Parse(key);
            if (nKey / 100 != idx && nKey / 100 < System.Enum.GetValues(typeof(ItemParameter.ItemType)).Length)//������ ���� �����ֱ�
            {
                idx++;
            }
            //Item.GetComponentsInChildren<Image>()[0].gameObject.SetActive(false);//�̹��� ���ӿ�����Ʈ ��ü�� ����
            GameObject Item = GameManager.instance.objectFactory.ItemObjectFactory.CreateObject(ItemPre);
            if (idx == (int)ItemParameter.ItemType.PROFESSIONAL)
            {
                var data = ProfessionalDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data);
            }
            else if (idx == (int)ItemParameter.ItemType.EQUIPMENT)
            {
                var data = EquipDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,InItem);
            }
            else if (idx == (int)ItemParameter.ItemType.GEMSTONE)
            {
                var data = GemStoneDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,InItem);
            }
            else if (idx == (int)ItemParameter.ItemType.MATERIAL)
            {
                var data = MaterialDatas[nKey % 100];
                Item.GetComponent<UiCellView>().SetUp(data,InItem);
            }

            Items[idx].Add(Item);
            //Item.GetComponentsInChildren<Image>()[0].enabled = false; //������Ʈ�� ����
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
        //            Item.GetComponentsInChildren<Image>()[0].enabled = false; //������Ʈ�� ����
        //            //Item.GetComponentsInChildren<Image>()[0].gameObject.SetActive(false);//�̹��� ���ӿ�����Ʈ ��ü�� ����
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
        //            GameObject Item = (GameObject)Instantiate(ItemPre, Content.transform);//content�Ʒ���
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
        for (int i = 0; i < Slot.Count; i++)
        {
            if (Slot[i].activeSelf && ItemData[i].GetComponent<UiCellView>().COUNT != 0)
            {
                Slot[i].GetComponentInChildren<TMP_Text>().text = ItemData[i].GetComponent<UiCellView>().COUNT.ToString();
            }
        }
    }
   
    public void ChangeEquipTab()
    {//������ ���� �Ѵ�
        slotManager.SetSlot(GameManager.instance.objectFactory.ItemSlotFactory.listPool, // �κ��丮�� ǥ���� ���� �̹��� (��ü ������ŭ)  AllItemId
                            GameManager.instance.objectFactory.ItemObjectFactory.listPool, // Uicellview ���� ����ִ� ����Ʈ(��ü ������ŭ)  
                            slotManager.SlotsInViewport,
                            SlotManager.OBJECT_TYPE.ITEM);
        List<GameObject> Slot = GameManager.instance.objectFactory.ItemSlotFactory.listPool;
        List<GameObject> ItemData = GameManager.instance.objectFactory.ItemObjectFactory.listPool;
        for (int i = 0; i < Slot.Count; i++)
        {
            if (ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.EQUIPMENT || ItemData[i].GetComponent<UiCellView>().TYPE == ItemParameter.ItemType.PROFESSIONAL)
            {
                Slot[i].gameObject.SetActive(true);
            }                
            else
                Slot[i].gameObject.SetActive(false);
           
            
        }
    }
    public void ChangeGemStoneTab()
    {

    }
    public void ChangeMaterialTab()
    {

    }
    public void ChangeTotalTab()
    {

    }

    #region CreatItem()
    //public void CreateItem()
    //{//ó��0���븸 ��������� �޹�ȣ�� �ȸ������? �ȸ������
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
    public void WriteData()
    {//�ʱ� �κ��丮 ��� ��� 0
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

        GameManager.instance.DataWrite(_strInvenItemPath + HaveInvenItem, dictTemp);

    }
   
    public void OpenDataPan(int index)
    {
        ShowData.SetActive(true);
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