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
/* 20230821
 * 
 */
#endregion
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
    // 초기화
    private void Init()
    {
        // 폴더 경로
        _strGraphicFolderPath = FolderPath.PARAMS_GRAPHIC;
        // 파일경로
        _strGraphicFileName = FileName.STR_GRAPHIC_VAULES;
        // 파일이 이미있다면 그파일 데이터 읽기, 아니면 초기값 설정
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
    // 데이터 읽어오기
    private void ReadValues()
    {
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicFolderPath + _strGraphicFileName);
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
        GameManager.instance.DataWrite(_strGraphicFolderPath + _strGraphicFileName, dictVolumeValues);
    }
    // String To ShadowResolution 컨버터
    private ShadowResolution ConvertStringToShadowResolution(string shadowResolution)
    {
        return (ShadowResolution)System.Enum.Parse(typeof(ShadowResolution), shadowResolution);
    }

    // 프레임 설정 30 60
    public void SetFrameRate(int nFrameRate)
    {
        Debug.Log($"SetFrameRate{nFrameRate}");
        _nFrameRate = nFrameRate;
        Application.targetFrameRate = nFrameRate;
        WriteValues();
    }
    // 안티앨리어싱 설정 0 2 4 8
    public void SetAntiAliasing(int nAntiNum)
    {
        Debug.Log($"SetAntiAliasing{nAntiNum}");
        _nAntiAliasing = nAntiNum;
        QualitySettings.antiAliasing = nAntiNum;
        WriteValues();
    }
    // 그림자 품질 Low Medium High VeryHigh 
    public void SetShadowResolution(string sShadowRes)
    {
        Debug.Log($"SetShadowResolution{sShadowRes}");
        _sShadowResolution = sShadowRes;
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(sShadowRes);
        WriteValues();
    }
    // 텍스처 품질 0 1 2
    public void SetTextureQuality(int nTextureNum)
    {
        Debug.Log($"SetTextureQuality{nTextureNum}");
        _nTextureQuality = nTextureNum;
        QualitySettings.masterTextureLimit = _nTextureQuality;
        //QualitySettings.SetQualityLevel(_nTextureQuality);
        WriteValues();
    }
    // 수직 동기화 0 1
    public void SetvSyncCount(int vSyncCount)
    {
        Debug.Log($"SetvSyncCount{vSyncCount}");
        _nVSyncCount = vSyncCount;
        QualitySettings.vSyncCount = vSyncCount;
        WriteValues();
    }

}
