using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
//using ItemParameter;
public class ItemDatamanager : MonoBehaviour
{//���̽� ���� �����ͼ� �迭��
    public static readonly ItemDatamanager instance = new ItemDatamanager();
    string _strInvenItemPath;//���
    string HaveInvenItem;//�����̸�
    public UiCellView itemPrefab;
    public ProfessionalData[] ProfessionalDatas;//0~
    public EquipData[] EquipDatas;//100~
    public GemStoneData[] GemStoneDatas;//200~
    public MaterialData[] MaterialDatas;//300~
   
    

    Dictionary<string, string> InItem = new Dictionary<string, string>();
    List<string> ItemId = new List<string>();//�����ϴ� ������ ���̵� ����Ʈ
    List<UiCellView> TotalItems = new List<UiCellView>();//��� ������ ����Ʈ
    List<UiCellView> ProI = new List<UiCellView>();
    List<UiCellView> EquipI = new List<UiCellView>();
    List<UiCellView> Gem = new List<UiCellView>();
    List<UiCellView> Mate = new List<UiCellView>();



    private void Start()
    {
        
        _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
        HaveInvenItem = FileName.STR_JSON_INVEN_ITEMS;//���̽� ���� ���鶧 �����Ϳ� ��ųʸ�Ȯ��
        InitInven();
        Debug.Log(GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem));
        CreateItem();
        
    }
    public void InitInven()
    {

        if (GameManager.instance.CheckExist(_strInvenItemPath, HaveInvenItem))
        {//������
            LoadInvenData();
        }
        //������
        else
            WriteData();//���� �����
        //���Ͽ� ��� ��� ����0���� ���� �Լ� ����
        
    }
    public void LoadInvenData()
    {
        InItem = GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem);

        foreach(string key in InItem.Keys)//�迭�� ù ���� Ű
        {
            if (int.Parse(InItem[key]) != 0)
                ItemId.Add(key);//>>���̵�� ��ũ���ͺ��� ���̵� ������ ���Կ� �����ֱ�
            
        }
    }
    public void CreateItem()
    {//ó��0���븸 ��������� �޹�ȣ�� �ȸ������
        foreach (string key in ItemId)
        {
            if (int.Parse(key) < 100)
            {
                for (int i = 0; i < ProfessionalDatas.Length; i++)
                    if (int.Parse(key) == ProfessionalDatas[i].fId)
                    {
                        var data = ProfessionalDatas[i];
                        UiCellView Item = Instantiate(itemPrefab);
                        //Item.transform.SetParent(this.transform);
                        Item.SetUp(data);
                        ProI.Add(Item);
                        TotalItems.Add(Item);

                    }
                Debug.Log("0:" + TotalItems.Count);
            }
            if (int.Parse(key) < 200)
            {
                for (int i = 100; i < EquipDatas.Length; i++)
                {
                    if (int.Parse(key) == EquipDatas[i].fId)
                    {
                        var data = EquipDatas[i];
                        UiCellView Item = Instantiate(itemPrefab);
                        //Item.transform.SetParent(this.transform);
                        Item.SetUp(data);
                        TotalItems.Add(Item);
                        EquipI.Add(Item);
                    }
                }
            }
            if (int.Parse(key) < 300)
            {
                for (int i = 200; i < GemStoneDatas.Length; i++)
                {
                    if (int.Parse(key) == GemStoneDatas[i].fId)
                    {
                        var data = GemStoneDatas[i];
                        UiCellView Item = Instantiate(itemPrefab);
                        //Item.transform.SetParent(this.transform);
                        Item.SetUp(data);
                        TotalItems.Add(Item);
                        Gem.Add(Item);
                    }
                }
            }         
            
            if (int.Parse(key) < 400)
            {
                for (int i = 300; i < MaterialDatas.Length; i++)
                {
                    if (int.Parse(key) == MaterialDatas[i].fId)
                    {
                        //MaterialData materialData = MaterialDatas[i];
                        var data = MaterialDatas[i];
                        UiCellView Item = Instantiate(itemPrefab);
                        //Item.transform.SetParent(this.transform);
                        Item.SetUp(data);
                        TotalItems.Add(Item);
                        Mate.Add(Item);
                    }
                }

            }
        }
        Debug.Log(TotalItems.Count);
        Debug.Log(Mate.Count);
        Debug.Log(MaterialDatas.Length);
    }
    public void DisplayEmpty()
    {//���Կ� ��ĭ ǥ��

    }
    public void ToSolt()
    {
        
        
       
    }
    public void WriteData()
    {//�ʱ� �κ��丮 ��� ��� 0
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("0", "0");
        dictTemp.Add("1", "0");
        dictTemp.Add("2", "0");
        dictTemp.Add("3", "0");
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
        ////������ȭ
        //EquipData[] arr= JsonConvert.DeserializeObject<EquipData[]>(json);
        ////foreach for ������ drc�� �߰�

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
