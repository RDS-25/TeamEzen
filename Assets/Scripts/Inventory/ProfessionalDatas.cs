using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemParameter;
[CreateAssetMenu(fileName = "Item_Data", menuName = "Item / Professionaldata")]
public class ProfessionalDatas : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType ItemType = ItemParameter.ItemType.PROFESSIONAL;
    [SerializeField]
    public List<ItemParameter.ProfessionalEquipParams> ProfessionalEquipParams;
}
