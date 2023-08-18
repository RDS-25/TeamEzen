using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region 타임라인
/* 20230816
 * 파일 체크
 */
/* 20230818
 * private void Init()
 * json 있으면 받아오기 없으면 새로만들기
 * private void ReadValues()
 * 데이터 받아오기
 * private void WriteValues()
 * 데이터 쓰기
 * public void SetFrameRate(int nFrameRate)
 * 프레임 설정 30 60
 * public void SetAntiAliasing(int nAntiNum)
 * 안티앨리어싱 설정 0 2 4 8
 * public void SetShadowResolution(string sShadowRes)
 * 그림자 품질 High Low Medium VeryHigh 
 * public void SetTextureQuality(int nTextureNum)
 * 텍스처 품질 0 1 2
 * public void SetvSyncCount(int vSyncCount) 
 * 수직 동기화 0 1
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
    // 초기화
    private void Init()
    {
        _strGraphicValueFolderPath = Application.persistentDataPath + "/ParamsFolder/";
        _strGraphicValueFileName = FilePath.STR_JSON_GRAPHIC_VALUE;
        if(GameManager.instance.CheckExist(_strGraphicValueFolderPath, _strGraphicValueFileName))
            ReadValues();
        else
            WriteValues();
    }
    // 데이터 읽어오기
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicValueFolderPath + _strGraphicValueFileName);
        _frameRate = int.Parse(dictVolumeValues["FrameRate"]);
        _antiAliasing= int.Parse(dictVolumeValues["AntiAliasing"]);
        _shadowResolution = dictVolumeValues["ShadowResolution"];
        _textureQuality = int.Parse(dictVolumeValues["TextureQuality"]);
        _nVSyncCount = int.Parse(dictVolumeValues["vSyncCount"]);
    }
    // 데이터 json 저장
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

    // 프레임 설정 30 60
    public void SetFrameRate(int nFrameRate)
    {
        _frameRate = nFrameRate;
        Application.targetFrameRate = nFrameRate;
    }
    // 안티앨리어싱 설정 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        QualitySettings.antiAliasing = 1;
    }
    // 그림자 품질 High Low Medium VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        _shadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
    }
    // 텍스처 품질 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        _textureQuality = nTextureNum;
        QualitySettings.masterTextureLimit = _textureQuality;
    }
    // 수직 동기화 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
    }

    
}
