using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemParameter;
[CreateAssetMenu(fileName = "Item_Data", menuName = "Item / Gemstonedata")]
public class GemstoneDatas : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType ItemType = ItemParameter.ItemType.GEMSTONE;
    [SerializeField]
    public List<ItemParameter.GemstoneParams> GemstoneParams;
}
