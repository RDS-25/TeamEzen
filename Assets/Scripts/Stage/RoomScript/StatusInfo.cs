using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status Data", menuName = "Scriptable Object/Status Data", order = int.MaxValue)]
public class StatusInfo : ScriptableObject
{
    public string eName;
    public string kName;
    public string[] lGold;
    public string[] lincrease;
}