using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
//using ItemParameter;
public class ItemDatamanager : MonoBehaviour
{//제이슨 파일 가져와서 배열로
    public static readonly ItemDatamanager instance = new ItemDatamanager();
    string _strInvenItemPath;//경로
    string HaveInvenItem;//파일이름
   

    Dictionary<string, string> InItem = new Dictionary<string, string>();
    List<string> ItemId = new List<string>();//존재하는 아이템 아이디 리스트
    List<GameObject> Itemdatas = new List<GameObject>();
    private void Start()
    {
        //Itemdatas.Add()
        _strInvenItemPath = FolderPath.INVEN;
        HaveInvenItem = FileName.STR_JSON_INVEN_ITEMS;//제이슨 파일 만들때 컨버터에 딕셔너리확인
        InitInven();
        Debug.Log(GameManager.instance.DataRead(_strInvenItemPath + HaveInvenItem));
    }
    public void InitInven()
    {

        if (GameManager.instance.CheckExist(_strInvenItemPath, HaveInvenItem))
        {//있을때
            LoadInvenData();
        }
        //없을때
        else
            File.Create(_strInvenItemPath + HaveInvenItem);//파일 만들기
        WriteData();
        //파일에 모든 장비 갯수0개로 쓰기 함수 따로
        
    }
    public void LoadInvenData()
    {
        InItem = GameManager.instance.DataRead(HaveInvenItem);

        foreach(string key in InItem.Keys)//배열의 첫 값이 키
        {
            if (int.Parse(InItem[key]) != 0)
                ItemId.Add(key);//아이디와 스크립터블의 아이디가 같으면 슬롯에 정보주기
        }
    }
    public void ToSolt()
    {
        foreach(string key in InItem.Keys)
        {
            
        }
    }
    public void DisplayEmpty()
    {//슬롯에 빈칸 표시

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
