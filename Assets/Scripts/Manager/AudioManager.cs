using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private string _strSoundFolderPath;
    private string _strSoundFileName;
    [SerializeField]
    private float _fMasterVolume = 1.0f;
    [SerializeField]
    private float _fBackgroundVolume = 1.0f;
    [SerializeField]
    private float _fEffectVolume = 1.0f;

    public float fMasterVolume { get { return _fMasterVolume; } }
    public float fBackgroundVolume { get { return _fBackgroundVolume; } }
    public float fEffectVolume { get { return _fEffectVolume; } }
    private Dictionary<string, AudioClip> _dictAudioClip = new Dictionary<string, AudioClip>();

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        //초기화
    }
    void Start()
    {
        Init();
    }
    private void Init()
    {
        // 폴더 경로
        _strSoundFolderPath = FolderPath.PARAMS_SOUND;
        // 파일경로
        _strSoundFileName = FileName.STR_SOUND_VALUES;
        // 파일이 이미있다면 그파일 데이터 읽기, 아니면 초기값 설정
        if (GameManager.instance.CheckExist(_strSoundFolderPath, _strSoundFileName))
            ReadVolumes();
        else
            WriteVolumes();
        // 오디오 클립 임시 배열 리소스폴더의 SoundClip 폴더 내 모든 audioclip 등록
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("SoundClip");
        // 배열에 담긴 audioClip을 _dictAudioClip에 이름을 키값으로 넣어줌
        foreach (AudioClip audio in audioClips)
        {
            if (!_dictAudioClip.ContainsKey(audio.name))
            {
                _dictAudioClip.Add(audio.name, audio);
            }
        }
    }
    private void ReadVolumes()
    {
        // 게임매니저로 데이터 읽어오기
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strSoundFolderPath + _strSoundFileName);
        // 볼륨값 저장된 값으로 지정
        _fMasterVolume      = float.Parse(dictVolumeValues["MasterVolume"]);
        _fBackgroundVolume  = float.Parse(dictVolumeValues["BackgroundVolume"]);
        _fEffectVolume      = float.Parse(dictVolumeValues["EffectVolume"]);
    }
    private void WriteVolumes()
    {
        Dictionary<string, string> dictVolumeValues = new();
        dictVolumeValues.Add("MasterVolume",    _fMasterVolume.ToString());
        dictVolumeValues.Add("BackgroundVolume",_fBackgroundVolume.ToString());
        dictVolumeValues.Add("EffectVolume",    _fEffectVolume.ToString());
        
        GameManager.instance.DataWrite(_strSoundFolderPath + _strSoundFileName, dictVolumeValues);
    }
    // 외부에서 호출할 배경음악 재생기
    public void PlayBackgroundSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // 배경음악 재생
            BackgroundSound(audioSource, _dictAudioClip[strClipName]);
        }
        else
        {
            Debug.LogError("배경음악 재생 실패");
        }
    }
    // 외부에서 호출할 이펙트 재생기
    public void PlayEffectSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // 이펙트 재생
            EffectSound(audioSource, _dictAudioClip[strClipName]);
        }
        else
        {
            Debug.LogError("효과음 재생 실패");
        }
    }
    // 배경음악 재생
    private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
    {
        // 받아온 AudioSource에 AudioClip을 넣고 볼륨 셋팅 후 재생
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fBackgroundVolume;
        audioSource.loop = true;
        audioSource.Play();
    }
    // 이펙트 재생
    private void EffectSound(AudioSource audioSource, AudioClip audioClip)
    {
        // 받아온 AudioSource에 AudioClip을 넣고 볼륨 셋팅 후 재생
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fEffectVolume;
        audioSource.loop = false;
        audioSource.PlayOneShot(audioClip);
    }
    // 오디오 소스의 볼륨값 업데이트
    void UpdateAllAudioSource()
    {
        // 오디오 소스 전부 찾아서
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        if(audioSources != null)
        {
            foreach (AudioSource audio in audioSources)
            {
                // 배경음악, 효과음을 루프로 구분하여
                if (audio.loop)
                {
                    // 배경음악 볼륨 설정
                    audio.volume = _fMasterVolume * _fBackgroundVolume;
                }
                else
                {
                    // 이펙트 볼륨 설정
                    audio.volume = _fMasterVolume * _fEffectVolume;
                }
            }
            WriteVolumes();
        }
        else
        {
            Debug.LogError("오디오 소스 참조 실패");
        }
    }
    // 마스터 볼륨 설정
    public void SetMasterVolume(float fVolume)
    {
        _fMasterVolume = fVolume;
        UpdateAllAudioSource();
    }
    // 배경 볼륨 설정
    public void SetBackgroundVolume(float fVolume)
    {
        _fBackgroundVolume = fVolume;
        UpdateAllAudioSource();
    }
    // 이펙트 볼륨 설정
    public void SetEffectVolume(float fVolume)
    {
        _fEffectVolume = fVolume;
        UpdateAllAudioSource();
    } 
}
