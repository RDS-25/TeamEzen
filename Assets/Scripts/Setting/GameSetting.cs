using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    public Toggle distanceToggle;
    public Toggle lowHpToggle;

    public void TargetDistance()
    {
        if(distanceToggle.isOn)
            GameManager.instance.bTargetingDistance = true;
    }
    public void TargetLowHp()
    {
        if(lowHpToggle.isOn)
            GameManager.instance.bTargetingDistance = false;
    }
}
