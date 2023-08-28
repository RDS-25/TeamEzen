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
    string _strInvenItemPath;
    string STR_JSON_INVEN_ITEMS;
    public void InitInven()
    {
        _strInvenItemPath = Application.dataPath + "/InvenItem/";
        if (!GameManager.instance.FolderExists(_strInvenItemPath))        
            Directory.CreateDirectory("_strInvenItemPath");
            _strInvenItemPath += "ItemInInven.json";
        if (GameManager.instance.FileExists(_strInvenItemPath))
        {//있을때
            LoadInvenData();
        }
        //없을때
        else
            DisplayEmpty();
        
    }
    public void LoadInvenData()
    {
        GameManager.instance.DataRead(STR_JSON_INVEN_ITEMS);
    }
    public void DisplayEmpty()
    {//슬롯에 빈칸 표시

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
