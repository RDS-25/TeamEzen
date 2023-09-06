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
    List<UiCellView> Items = new List<UiCellView>();//��� ������ ����Ʈ
    
    
    private void Start()
    {

        _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
        HaveInvenItem = FileName.STR_JSON_INVEN_ITEMS;//���̽� ���� ���鶧 �����Ϳ� ��ųʸ�Ȯ��
        InitInven();
        Debug.Log(GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem));
    }
    public void InitInven()
    {

        if (GameManager.instance.CheckExist(_strInvenItemPath, HaveInvenItem))
        {//������
            LoadInvenData();
        }
        //������
        else
            File.Create(_strInvenItemPath + HaveInvenItem);//���� �����
        WriteData();
        //���Ͽ� ��� ��� ����0���� ���� �Լ� ����
        
    }
    public void LoadInvenData()
    {
        InItem = GameManager.instance.DataRead(HaveInvenItem);

        foreach(string key in InItem.Keys)//�迭�� ù ���� Ű
        {
            if (int.Parse(InItem[key]) != 0)
                ItemId.Add(key);//>>���̵�� ��ũ���ͺ��� ���̵� ������ ���Կ� �����ֱ�
        }
    }
    public void CreateItem()
    {
        foreach (string key in InItem.Keys)
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
                        Items.Add(Item);
                    }
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
                        Items.Add(Item);
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
                        Items.Add(Item);
                    }
                }
            }
            if (int.Parse(key) < 400)
            {
                for (int i = 300; i < MaterialDatas.Length; i++)
                {
                    if (int.Parse(key) == MaterialDatas[i].fId)
                    {
                        var data = MaterialDatas[i];
                        MaterialData materialData = MaterialDatas[i];
                        UiCellView Item = Instantiate(itemPrefab);
                        //Item.transform.SetParent(this.transform);
                        Item.SetUp(data);
                        Items.Add(Item);
                    }
                }
            }
        }
    }
    public void DisplayEmpty()
    {//���Կ� ��ĭ ǥ��

    }
    public void ToSolt()
    {
        
        
       
    }
    public void WriteData()
    {//�ʱ� �κ��丮 ��� ��� 0

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
