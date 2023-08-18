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
/* 20230818
 * frame, anti, vsync, shadow, texture 각 버튼용 함수 생성
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
    public void SetTexture0()
    {
        GraphicManager.instance.SetTextureQuality(0);
    }
    public void SetTexture1()
    {
        GraphicManager.instance.SetTextureQuality(1);
    }
    public void SetTexture2()
    {
        GraphicManager.instance.SetTextureQuality(2);
    }

    public void AntiAliasingx0()
    {
        GraphicManager.instance.SetAntiAliasing(0);
    }
    public void AntiAliasingx2()
    {
        GraphicManager.instance.SetAntiAliasing(2);
    }
    public void AntiAliasingx4()
    {
        GraphicManager.instance.SetAntiAliasing(4);
    }
    public void AntiAliasingx8()
    {
        GraphicManager.instance.SetAntiAliasing(8);
    }

    public void VSyncOn()
    {
        GraphicManager.instance.SetvSyncCount(1);
    }
    public void VSyncOff()
    {
        GraphicManager.instance.SetvSyncCount(0);
    }

    public void SetFrame30()
    {
        GraphicManager.instance.SetFrameRate(30);
    }
    public void SetFrame60()
    {
        GraphicManager.instance.SetFrameRate(60);
    }

    public void SetShadowLow()
    {
        GraphicManager.instance.SetShadowResolution("Low");
    }
    public void SetShadowMedium()
    {
        GraphicManager.instance.SetShadowResolution("Medium");
    }
    public void SetShadowHigh()
    {
        GraphicManager.instance.SetShadowResolution("High");
    }
    public void SetShadowVeryHigh()
    {
        GraphicManager.instance.SetShadowResolution("VeryHigh");
    }

}
