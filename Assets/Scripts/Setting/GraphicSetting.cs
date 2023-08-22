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
/* 20230821
 * 텍스처, 안티앨리어싱, 수직동기화, 프레임, 그림자 토글버튼 추가
 * void Init()
 * 데이터 저장된 값으로 초기화하여 일치시키기
 */
#endregion
public class GraphicSetting : MonoBehaviour
{
    public Toggle texture0Toggle;
    public Toggle texture1Toggle;
    public Toggle texture2Toggle;

    public Toggle antix0;
    public Toggle antix2;
    public Toggle antix4;
    public Toggle antix8;

    public Toggle vSyncOn;
    public Toggle vSyncOff;

    public Toggle frame30;
    public Toggle frame60;

    public Toggle shadowLow;
    public Toggle shadowMedium;
    public Toggle shadowHigh;
    public Toggle shadowVeryHigh;

    void Awake()
    {
        Init();
    }
    void Init()
    {
        if (GraphicManager.instance.nFrameRate == 30)
        {
            frame30.isOn = true;
            frame60.isOn = false;
        }
        else if (GraphicManager.instance.nFrameRate == 60)
        {
            frame30.isOn = false;
            frame60.isOn = true;
        }

        if (GraphicManager.instance.nTextureQuality == 0)
        {
            texture0Toggle.isOn = true;
            texture1Toggle.isOn = false;
            texture2Toggle.isOn = false;
        }
        else if (GraphicManager.instance.nTextureQuality == 1)
        {
            texture0Toggle.isOn = false;
            texture1Toggle.isOn = true;
            texture2Toggle.isOn = false;
        }
        else if (GraphicManager.instance.nTextureQuality == 2)
        {
            texture0Toggle.isOn = false;
            texture1Toggle.isOn = false;
            texture2Toggle.isOn = true;
        }

        if (GraphicManager.instance.sShadowResolution == "Low")
        {
            shadowLow.isOn = true;
            shadowMedium.isOn = false;
            shadowHigh.isOn = false;
            shadowVeryHigh.isOn = false;
        }
        else if (GraphicManager.instance.sShadowResolution == "Medium")
        {
            shadowLow.isOn = false;
            shadowMedium.isOn = true;
            shadowHigh.isOn = false;
            shadowVeryHigh.isOn = false;
        }
        else if (GraphicManager.instance.sShadowResolution == "High")
        {
            shadowLow.isOn = false;
            shadowMedium.isOn = false;
            shadowHigh.isOn = true;
            shadowVeryHigh.isOn = false;
        }
        else if (GraphicManager.instance.sShadowResolution == "VeryHigh")
        {
            shadowLow.isOn = false;
            shadowMedium.isOn = false;
            shadowHigh.isOn = false;
            shadowVeryHigh.isOn = true;
        }

        if (GraphicManager.instance.nAntiAliasing == 0)
        {
            antix0.isOn = true;
            antix2.isOn = false;
            antix4.isOn = false;
            antix8.isOn = false;
        }
        else if (GraphicManager.instance.nAntiAliasing == 2)
        {
            antix0.isOn = false;
            antix2.isOn = true;
            antix4.isOn = false;
            antix8.isOn = false;
        }
        else if (GraphicManager.instance.nAntiAliasing == 4)
        {
            antix0.isOn = false;
            antix2.isOn = false;
            antix4.isOn = true;
            antix8.isOn = false;
        }
        else if (GraphicManager.instance.nAntiAliasing == 8)
        {
            antix0.isOn = false;
            antix2.isOn = false;
            antix4.isOn = false;
            antix8.isOn = true;
        }

        if (GraphicManager.instance.nVSyncCount == 0)
        {
            vSyncOff.isOn = true;
            vSyncOn.isOn = false;
        }
        else if (GraphicManager.instance.nVSyncCount == 1)
        {
            vSyncOff.isOn = false;
            vSyncOn.isOn = true;
        }
    }
    public void SetTextureLow()
    {
        if(texture0Toggle.isOn)
            GraphicManager.instance.SetTextureQuality(0);
    }
    public void SetTextureMedium()
    {
        if (texture1Toggle.isOn)
            GraphicManager.instance.SetTextureQuality(1);
    }
    public void SetTextureHigh()
    {
        if (texture2Toggle.isOn)
            GraphicManager.instance.SetTextureQuality(2);
    }


    public void SetAntiAliasingx0()
    {
        if (antix0.isOn)
            GraphicManager.instance.SetAntiAliasing(0);
    }
    public void SetAntiAliasingx2()
    {
        if (antix2.isOn)
            GraphicManager.instance.SetAntiAliasing(2);
    }
    public void SetAntiAliasingx4()
    {
        if (antix4.isOn)
            GraphicManager.instance.SetAntiAliasing(4);
    }
    public void SetAntiAliasingx8()
    {
        if (antix8.isOn)
            GraphicManager.instance.SetAntiAliasing(8);
    }


    public void SetVSyncOn()
    {
        if (vSyncOn.isOn)
            GraphicManager.instance.SetvSyncCount(1);
    }
    public void SetVSyncOff()
    {
        if (vSyncOff.isOn)
            GraphicManager.instance.SetvSyncCount(0);
    }


    public void SetFrame30()
    {
        if (frame30.isOn)
            GraphicManager.instance.SetFrameRate(30);
    }
    public void SetFrame60()
    {
        if (frame60.isOn)
            GraphicManager.instance.SetFrameRate(60);
    }


    public void SetShadowLow()
    {
        if(shadowLow.isOn)
            GraphicManager.instance.SetShadowResolution("Low");
    }
    public void SetShadowMedium()
    {
        if (shadowMedium.isOn)
            GraphicManager.instance.SetShadowResolution("Medium");
    }
    public void SetShadowHigh()
    {
        if (shadowHigh.isOn)
            GraphicManager.instance.SetShadowResolution("High");
    }
    public void SetShadowVeryHigh()
    {
        if (shadowVeryHigh.isOn)
            GraphicManager.instance.SetShadowResolution("VeryHigh");
    }

}
