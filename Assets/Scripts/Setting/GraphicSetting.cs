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
    public Toggle texture0Toggle;
    public Toggle texture1Toggle;
    public Toggle texture2Toggle;

    public ToggleGroup textureToggleGroup;

    public Toggle antix0;
    public Toggle antix2;
    public Toggle antix4;
    public Toggle antix8;

    public Toggle vSync;

    public Toggle frame30;
    public Toggle frame60;

    public Toggle shadowLow;
    public Toggle shadowMedium;
    public Toggle shadowHigh;
    public Toggle shadowVeryHigh;

    public void SetTextureLow()
    {
        GraphicManager.instance.SetTextureQuality(0);
    }
    public void SetTextureMedium()
    {
        GraphicManager.instance.SetTextureQuality(1);
    }
    public void SetTextureHigh()
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
        if(vSync.isOn == false)
        {
            vSync.isOn = true;
            GraphicManager.instance.SetvSyncCount(1);
        }
        else
        {
            vSync.isOn = true;
            GraphicManager.instance.SetvSyncCount(0);
        }
    }


    public void SetFrame30()
    {
        frame30.isOn = true;
        frame60.isOn = false;
        GraphicManager.instance.SetFrameRate(30);
    }
    public void SetFrame60()
    {
        frame30.isOn = false;
        frame60.isOn = true;
        GraphicManager.instance.SetFrameRate(60);
    }

    public void SetShadowLow()
    {
        shadowLow.isOn = true;
        shadowMedium.isOn = false;
        shadowHigh.isOn = false;
        shadowVeryHigh.isOn = false;
        GraphicManager.instance.SetShadowResolution("Low");
    }
    public void SetShadowMedium()
    {
        shadowLow.isOn = false;
        shadowMedium.isOn = true;
        shadowHigh.isOn = false;
        shadowVeryHigh.isOn = false;
        GraphicManager.instance.SetShadowResolution("Medium");
    }
    public void SetShadowHigh()
    {
        shadowLow.isOn = false;
        shadowMedium.isOn = false;
        shadowHigh.isOn = true;
        shadowVeryHigh.isOn = false;
        GraphicManager.instance.SetShadowResolution("High");
    }
    public void SetShadowVeryHigh()
    {
        shadowLow.isOn = false;
        shadowMedium.isOn = false;
        shadowHigh.isOn = false;
        shadowVeryHigh.isOn = true;
        GraphicManager.instance.SetShadowResolution("VeryHigh");
    }

}
