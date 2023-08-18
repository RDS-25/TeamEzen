using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 타임라인
/* 20230816
 * void Init(Dictionary<string, string> dict)
 * 그래픽 설정값 불러오기
 * 
 */
/*  
 * 
 * 
 * 
 */
#endregion
public class GraphicSetting : MonoBehaviour
{
    public Toggle toggle;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        if (toggle.isOn == false)
            toggle.isOn = true;
        else
            toggle.isOn = false;
    }
    void Init(Dictionary<string, string> dict)
    {
        QualitySettings.antiAliasing = 2;
        QualitySettings.shadowResolution = ShadowResolution.Low;
    }
}
