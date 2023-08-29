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
   

    Dictionary<string, string> InItem = new Dictionary<string, string>();
    List<string> ItemId = new List<string>();//�����ϴ� ������ ���̵� ����Ʈ
    List<GameObject> Itemdatas = new List<GameObject>();
    private void Start()
    {
        //Itemdatas.Add()
        _strInvenItemPath = FolderPath.INVEN;
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
                ItemId.Add(key);//���̵�� ��ũ���ͺ��� ���̵� ������ ���Կ� �����ֱ�
        }
    }
    public void ToSolt()
    {
        foreach(string key in InItem.Keys)
        {
            
        }
    }
    public void DisplayEmpty()
    {//���Կ� ��ĭ ǥ��

    }
    public void CheckItem()
    {
        for(int i=0;i<InItem.Count ;i++)
        {
            
            //if (int.Parse(InItem[i]["fId"]))
        }
       
    }
    public void WriteData()
    {

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
