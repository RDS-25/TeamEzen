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
    // 초기화
    private void Init()
    {
        _strGraphicValueFolderPath = Application.persistentDataPath + "/ParamsFolder/";
        _strGraphicValueFileName = FileName.STR_GRAPHIC_VAULES;
        if(GameManager.instance.CheckExist(_strGraphicValueFolderPath, _strGraphicValueFileName))
            ReadValues();
        else
            WriteValues();
    }
    // 데이터 읽어오기
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicValueFolderPath + _strGraphicValueFileName);
        _nFrameRate = int.Parse(dictVolumeValues["FrameRate"]);
        _nAntiAliasing= int.Parse(dictVolumeValues["AntiAliasing"]);
        _sShadowResolution = dictVolumeValues["ShadowResolution"];
        _nTextureQuality = int.Parse(dictVolumeValues["TextureQuality"]);
        _nVSyncCount = int.Parse(dictVolumeValues["vSyncCount"]);
    }
    // 데이터 json 저장
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
    // String To ShadowResolution 컨버터
    private ShadowResolution ConvertStringToShadowResolution(string shadowResolution)
    {
        return (ShadowResolution)System.Enum.Parse(typeof(ShadowResolution), shadowResolution);
    }

    // 프레임 설정 30 60
    public void SetFrameRate(int nFrameRate)
    {
        _nFrameRate = nFrameRate;
        Application.targetFrameRate = nFrameRate;
    }
    // 안티앨리어싱 설정 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        QualitySettings.antiAliasing = nAntiNum;
    }
    // 그림자 품질 High Low Medium VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        _sShadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
    }
    // 텍스처 품질 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        _nTextureQuality = nTextureNum;
        QualitySettings.SetQualityLevel(_nTextureQuality);
    }
    // 수직 동기화 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
    }

    
}
