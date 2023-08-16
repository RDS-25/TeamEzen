using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
