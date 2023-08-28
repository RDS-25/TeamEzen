using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
//using ItemParameter;
public class ItemDatamanager : MonoBehaviour
{
    public static readonly ItemDatamanager instance = new ItemDatamanager();
    Dictionary<float, EquipData> dicEquipData;
    ItemParameter.EquipParams equip = new ItemParameter.EquipParams(); 
    public void LoadEquipData()
    {
        Debug.Log(equip.fId);
        TextAsset asset= Resources.Load<TextAsset>("Test/Equip_Data");
        string json = asset.text;
        //역직렬화
        EquipData[] arr= JsonConvert.DeserializeObject<EquipData[]>(json);
        //foreach for 돌리며 drc에 추가
        this.dicEquipData= arr.ToDictionary(x => x.EquipParams.fId);
        Debug.Log("load");
        Debug.LogFormat("item data count:{0}",this.dicEquipData.Count);
    }
    public EquipData GetIEquipData(float fId)
    {
        if (this.dicEquipData.ContainsKey(fId))
        {
            return this.dicEquipData[fId];
        }
        Debug.LogFormat("key({0}) not found.", fId);
        return null;
    }
}
