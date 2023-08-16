using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 타임라인
/* 20230811
 * Slider마다 AddListener 추가
 * public void UpdateMasterVolume(float fValue)
 * 마스터 볼륨 업데이트
 * public void UpdateBackgroundVolume(float fValue)
 * 배경 볼륨 업데이트
 * public void UpdateEffectVolume(float fValue)
 * 효과음 볼륨 업데이트
 * 
 */
/* 20230814
 * void Init()
 * 초기 사운드 값 저장된 데이터와 일치시키기
 */
#endregion
public class SoundSetting : MonoBehaviour
{
    public Slider sliderMasterVolume;
    public Slider sliderBackgroundVolume;
    public Slider sliderEffectVolume;

    private void Start()
    {
        Init();
        sliderMasterVolume.onValueChanged.AddListener(UpdateMasterVolume);
        sliderBackgroundVolume.onValueChanged.AddListener(UpdateBackgroundVolume);
        sliderEffectVolume.onValueChanged.AddListener(UpdateEffectVolume);
    }
    void Init()
    {
        // 슬라이더 값을 오디오 매니저의 값을 불러와 일치시킴
        sliderMasterVolume.value = AudioManager.instance.fMasterVolume;
        sliderBackgroundVolume.value = AudioManager.instance.fBackgroundVolume;
        sliderEffectVolume.value = AudioManager.instance.fEffectVolume;

    }
    // 볼륨 업데이트
    public void UpdateMasterVolume(float fValue)
    {
        AudioManager.instance.SetMasterVolume(fValue);
    }
    public void UpdateBackgroundVolume(float fValue)
    {
        AudioManager.instance.SetBackgroundVolume(fValue);
    }
    public void UpdateEffectVolume(float fValue)
    {
        AudioManager.instance.SetEffectVolume(fValue);
    }
}
