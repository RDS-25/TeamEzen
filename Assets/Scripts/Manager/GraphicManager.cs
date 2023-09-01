using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GraphicManager : MonoBehaviour
{
    public static GraphicManager instance;
    private string _strGraphicFolderPath;
    private string _strGraphicFileName;

    private int _nFrameRate = 30;
    private int _nAntiAliasing = 0;
    private string _sShadowResolution = "Low";
    private int _nTextureQuality = 0;
    private int _nVSyncCount = 0;

    public int nFrameRate { get { return _nFrameRate; } }
    public int nAntiAliasing { get { return _nAntiAliasing; } }
    public string sShadowResolution { get { return _sShadowResolution; } }
    public int nTextureQuality { get { return _nTextureQuality; } }
    public int nVSyncCount { get { return _nVSyncCount; } }
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Init();
    }
    // �ʱ�ȭ
    private void Init()
    {
        // ���� ���
        _strGraphicFolderPath = FolderPath.PARAMS_GRAPHIC;
        // ���ϰ��
        _strGraphicFileName = FileName.STR_GRAPHIC_VAULES;
        // ������ �̹��ִٸ� ������ ������ �б�, �ƴϸ� �ʱⰪ ����
        if (GameManager.instance.CheckExist(_strGraphicFolderPath, _strGraphicFileName))
            ReadValues();
        else
            WriteValues();
        SetAntiAliasing(_nAntiAliasing);
        SetFrameRate(_nFrameRate);
        SetShadowResolution(_sShadowResolution);
        SetTextureQuality(_nTextureQuality);
        SetvSyncCount(_nVSyncCount);
    }
    // ������ �о����
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicFolderPath + _strGraphicFileName);
        _nFrameRate = int.Parse(dictVolumeValues["FrameRate"]);
        _nAntiAliasing= int.Parse(dictVolumeValues["AntiAliasing"]);
        _sShadowResolution = dictVolumeValues["ShadowResolution"];
        _nTextureQuality = int.Parse(dictVolumeValues["TextureQuality"]);
        _nVSyncCount = int.Parse(dictVolumeValues["vSyncCount"]);
    }
    // ������ json ����
    private void WriteValues()
    {
        Dictionary<string, string> dictVolumeValues = new();
        dictVolumeValues.Add("FrameRate", _nFrameRate.ToString());
        dictVolumeValues.Add("AntiAliasing", _nAntiAliasing.ToString());
        dictVolumeValues.Add("ShadowResolution", _sShadowResolution);
        dictVolumeValues.Add("TextureQuality", _nTextureQuality.ToString());
        dictVolumeValues.Add("vSyncCount", _nVSyncCount.ToString());
        GameManager.instance.DataWrite(_strGraphicFolderPath + _strGraphicFileName, dictVolumeValues);
    }
    // String To ShadowResolution ������
    private ShadowResolution ConvertStringToShadowResolution(string shadowResolution)
    {
        return (ShadowResolution)System.Enum.Parse(typeof(ShadowResolution), shadowResolution);
    }

    // ������ ���� 30 60
    public void SetFrameRate(int nFrameRate)
    {
        _nFrameRate = nFrameRate;
        Application.targetFrameRate = nFrameRate;
        WriteValues();
    }
    // ��Ƽ�ٸ���� ���� 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        _nAntiAliasing = nAntiNum;
        QualitySettings.antiAliasing = nAntiNum;
        WriteValues();
    }
    // �׸��� ǰ�� Low Medium High VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        _sShadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
        WriteValues();
    }
    // �ؽ�ó ǰ�� 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        _nTextureQuality = nTextureNum;
        QualitySettings.masterTextureLimit = _nTextureQuality;
        //QualitySettings.SetQualityLevel(_nTextureQuality);
        WriteValues();
    }
    // ���� ����ȭ 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
        WriteValues();
    }

}
