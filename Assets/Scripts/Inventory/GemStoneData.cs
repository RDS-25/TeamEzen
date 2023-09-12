using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GemStoneData_", menuName = "Item / GemStoneData")]

public class GemStoneData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.GEMSTONE;
    public float fId;//보석 고유번호
    public string strName;//보석 이름
    public string strDiscription;//장비 설명
    public string strImage;//아이템 이미지 주소
    public float fDropRate;//보석 드랍율
    public float fUpDamage;//보석이 올려주는 스킬 대미지비율
    public float fCount;//갯수
}
