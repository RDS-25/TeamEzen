using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region Ÿ�Ӷ���
/* 20230816
 * ���� üũ
 */
/* 20230818
 * private void Init()
 * json ������ �޾ƿ��� ������ ���θ����
 * private void ReadValues()
 * ������ �޾ƿ���
 * private void WriteValues()
 * ������ ����
 * public void SetFrameRate(int nFrameRate)
 * ������ ���� 30 60
 * public void SetAntiAliasing(int nAntiNum)
 * ��Ƽ�ٸ���� ���� 0 2 4 8
 * public void SetShadowResolution(string sShadowRes)
 * �׸��� ǰ�� High Low Medium VeryHigh 
 * public void SetTextureQuality(int nTextureNum)
 * �ؽ�ó ǰ�� 0 1 2
 * public void SetvSyncCount(int vSyncCount) 
 * ���� ����ȭ 0 1
 */
#endregion
public class GraphicManager : MonoBehaviour
{
    public static GraphicManager instance;
    private static string _strGraphicValueFolderPath;
    private static string _strGraphicValueFileName;

    private int _nFrameRate = 30;
    private int _nAntiAliasing = 0;
    private string _sShadowResolution = "Low";
    private int _nTextureQuality = 0;
    private int _nVSyncCount = 0;

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
        _strGraphicValueFolderPath = Application.persistentDataPath + "/ParamsFolder/";
        _strGraphicValueFileName = FileName.STR_GRAPHIC_VAULES;
        if(GameManager.instance.CheckExist(_strGraphicValueFolderPath, _strGraphicValueFileName))
            ReadValues();
        else
            WriteValues();
    }
    // ������ �о����
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicValueFolderPath + _strGraphicValueFileName);
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
        GameManager.instance.DataWrite(_strGraphicValueFolderPath + _strGraphicValueFileName, dictVolumeValues);
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
    }
    // ��Ƽ�ٸ���� ���� 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        QualitySettings.antiAliasing = nAntiNum;
    }
    // �׸��� ǰ�� High Low Medium VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        _sShadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
    }
    // �ؽ�ó ǰ�� 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        _nTextureQuality = nTextureNum;
        QualitySettings.SetQualityLevel(_nTextureQuality);
    }
    // ���� ����ȭ 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
    }

    
}
