using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemParameter;

public class MaterialData : MonoBehaviour
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.MATERIAL;
    public MaterialParams MaterialParams;
}
