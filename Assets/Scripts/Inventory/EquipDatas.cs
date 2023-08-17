using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemParameter;
[CreateAssetMenu(fileName = "Item_Data", menuName = "Item / Equipdata")]
public class EquipDatas : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType ItemType = ItemParameter.ItemType.EQUIPMENT;
    [SerializeField]
    public List<ItemParameter.EquipParams> EquipParams;
}
