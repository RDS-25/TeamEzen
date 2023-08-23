using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    public Toggle distanceToggle;
    public Toggle lowHpToggle;

    void Start()
    {
        Init();
    }
    void Init()
    {
        if (GameManager.instance.bTargetingDistance == true)
        {
            distanceToggle.isOn = true;
            lowHpToggle.isOn = false;
        }
        else if (GameManager.instance.bTargetingDistance == false)
        {
            distanceToggle.isOn = false;
            lowHpToggle.isOn = true;
        }
    }
    public void TargetDistance()
    {
        if(distanceToggle.isOn)
            GameManager.instance.SetTargeting(true);
    }
    public void TargetLowHp()
    {
        if(lowHpToggle.isOn)
            GameManager.instance.SetTargeting(false);
    }
}
