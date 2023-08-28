using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialData_", menuName = "Item / MaterialData")]
public class MaterialData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.MATERIAL;
    public float fId;
    public string strName;
    public string strDiscription;
    public string strImage;//������ �̹��� �ּ�
    public float fDropRate;
    public float fExp;
    public float fNumber;//����
}
