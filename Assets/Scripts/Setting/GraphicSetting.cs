using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region Ÿ�Ӷ���
/* 20230816
 * void Init(Dictionary<string, string> dict)
 * �׷��� ������ �ҷ�����
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
