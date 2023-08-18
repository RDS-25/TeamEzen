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

    private int _frameRate = 30;
    private int _antiAliasing = 0;
    private string _shadowResolution = "Low";
    private int _textureQuality = 0;
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
        _strGraphicValueFileName = FilePath.STR_JSON_GRAPHIC_VALUE;
        if(GameManager.instance.CheckExist(_strGraphicValueFolderPath, _strGraphicValueFileName))
            ReadValues();
        else
            WriteValues();
    }
    // ������ �о����
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicValueFolderPath + _strGraphicValueFileName);
        _frameRate = int.Parse(dictVolumeValues["FrameRate"]);
        _antiAliasing= int.Parse(dictVolumeValues["AntiAliasing"]);
        _shadowResolution = dictVolumeValues["ShadowResolution"];
        _textureQuality = int.Parse(dictVolumeValues["TextureQuality"]);
        _nVSyncCount = int.Parse(dictVolumeValues["vSyncCount"]);
    }
    // ������ json ����
    private void WriteValues()
    {
        Dictionary<string, string> dictVolumeValues = new();
        dictVolumeValues.Add("FrameRate", _frameRate.ToString());
        dictVolumeValues.Add("AntiAliasing", _antiAliasing.ToString());
        dictVolumeValues.Add("ShadowResolution", _shadowResolution);
        dictVolumeValues.Add("TextureQuality", _textureQuality.ToString());
        dictVolumeValues.Add("vSyncCount", _nVSyncCount.ToString());
        GameManager.instance.DataWrite(_strGraphicValueFolderPath + _strGraphicValueFileName, dictVolumeValues);
    }
    private ShadowResolution ConvertStringToShadowResolution(string shadowResolution)
    {
        return (ShadowResolution)System.Enum.Parse(typeof(ShadowResolution), shadowResolution);
    }

    // ������ ���� 30 60
    public void SetFrameRate(int nFrameRate)
    {
        _frameRate = nFrameRate;
        Application.targetFrameRate = nFrameRate;
    }
    // ��Ƽ�ٸ���� ���� 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        QualitySettings.antiAliasing = 1;
    }
    // �׸��� ǰ�� High Low Medium VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        _shadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
    }
    // �ؽ�ó ǰ�� 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        _textureQuality = nTextureNum;
        QualitySettings.masterTextureLimit = _textureQuality;
    }
    // ���� ����ȭ 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
    }

    
}
