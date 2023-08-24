using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemParameter;

public class EquipInfo : MonoBehaviour
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.EQUIPMENT;
    public EquipParams EquipParams;
}
