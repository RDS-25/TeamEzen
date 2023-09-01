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
        //�ʱ�ȭ
    }
    void Start()
    {
        Init();
    }
    private void Init()
    {
        // ���� ���
        _strSoundFolderPath = FolderPath.PARAMS_SOUND;
        // ���ϰ��
        _strSoundFileName = FileName.STR_SOUND_VALUES;
        // ������ �̹��ִٸ� ������ ������ �б�, �ƴϸ� �ʱⰪ ����
        if (GameManager.instance.CheckExist(_strSoundFolderPath, _strSoundFileName))
            ReadVolumes();
        else
            WriteVolumes();
        // ����� Ŭ�� �ӽ� �迭 ���ҽ������� SoundClip ���� �� ��� audioclip ���
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("SoundClip");
        // �迭�� ��� audioClip�� _dictAudioClip�� �̸��� Ű������ �־���
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
        // ���ӸŴ����� ������ �о����
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strSoundFolderPath + _strSoundFileName);
        // ������ ����� ������ ����
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
    // �ܺο��� ȣ���� ������� �����
    public void PlayBackgroundSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // ������� ���
            BackgroundSound(audioSource, _dictAudioClip[strClipName]);
        }
        else
        {
            Debug.LogError("������� ��� ����");
        }
    }
    // �ܺο��� ȣ���� ����Ʈ �����
    public void PlayEffectSound(AudioSource audioSource, string strClipName)
    {
        if (_dictAudioClip.ContainsKey(strClipName))
        {
            // ����Ʈ ���
            EffectSound(audioSource, _dictAudioClip[strClipName]);
        }
        else
        {
            Debug.LogError("ȿ���� ��� ����");
        }
    }
    // ������� ���
    private void BackgroundSound(AudioSource audioSource, AudioClip audioClip)
    {
        // �޾ƿ� AudioSource�� AudioClip�� �ְ� ���� ���� �� ���
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fBackgroundVolume;
        audioSource.loop = true;
        audioSource.Play();
    }
    // ����Ʈ ���
    private void EffectSound(AudioSource audioSource, AudioClip audioClip)
    {
        // �޾ƿ� AudioSource�� AudioClip�� �ְ� ���� ���� �� ���
        audioSource.clip = audioClip;
        audioSource.volume = _fMasterVolume * _fEffectVolume;
        audioSource.loop = false;
        audioSource.PlayOneShot(audioClip);
    }
    // ����� �ҽ��� ������ ������Ʈ
    void UpdateAllAudioSource()
    {
        // ����� �ҽ� ���� ã�Ƽ�
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        if(audioSources != null)
        {
            foreach (AudioSource audio in audioSources)
            {
                // �������, ȿ������ ������ �����Ͽ�
                if (audio.loop)
                {
                    // ������� ���� ����
                    audio.volume = _fMasterVolume * _fBackgroundVolume;
                }
                else
                {
                    // ����Ʈ ���� ����
                    audio.volume = _fMasterVolume * _fEffectVolume;
                }
            }
            WriteVolumes();
        }
        else
        {
            Debug.LogError("����� �ҽ� ���� ����");
        }
    }
    // ������ ���� ����
    public void SetMasterVolume(float fVolume)
    {
        _fMasterVolume = fVolume;
        UpdateAllAudioSource();
    }
    // ��� ���� ����
    public void SetBackgroundVolume(float fVolume)
    {
        _fBackgroundVolume = fVolume;
        UpdateAllAudioSource();
    }
    // ����Ʈ ���� ����
    public void SetEffectVolume(float fVolume)
    {
        _fEffectVolume = fVolume;
        UpdateAllAudioSource();
    } 
}
