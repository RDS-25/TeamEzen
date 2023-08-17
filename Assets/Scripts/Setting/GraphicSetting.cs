using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void Init(Dictionary<string, string> dict)
    {
        QualitySettings.antiAliasing = 2;
        QualitySettings.shadowResolution = ShadowResolution.Low;
    }
}
