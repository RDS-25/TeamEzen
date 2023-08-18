using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region 타임라인
/* 20230816
 * 
 * 파일 존재 체크
 * 
 */
/*  
 * 
 * 
 * 
 */
#endregion
public class GraphicManager : MonoBehaviour
{
    public static GraphicManager instance;
    private static string _strGraphicValueFolderPath;
    private static string _strGraphicValueFileName;

    private int _antiAliasing;
    private string _shadowResolution;
    private int _textureQuality;
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
        _textureQuality = 2;
        QualitySettings.masterTextureLimit = _textureQuality;

        _shadowResolution = "High";
        _shadowResolution = ConvertShadowResolutionToString(ShadowResolution.Low);
        QualitySettings.shadowResolution = ConvertStringToShadowResolution(_shadowResolution);
        Init();
    }

    private void Init()
    {
        _strGraphicValueFolderPath = Application.persistentDataPath + "/ParamsFolder/";
        _strGraphicValueFileName = FilePath.STR_JSON_GRAPHIC_VALUE;
        if(GameManager.instance.CheckExist(_strGraphicValueFolderPath, _strGraphicValueFileName))
            ReadValues();
        else
            WriteValues();
    }
    private string ConvertShadowResolutionToString(ShadowResolution shadowResolution)
    {
        return shadowResolution.ToString();
    }

    private ShadowResolution ConvertStringToShadowResolution(string shadowResolution)
    {
        return (ShadowResolution)System.Enum.Parse(typeof(ShadowResolution), shadowResolution);
    }
    private void SetFrameRate(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }

    private void ReadValues()
    {
        // 데이터 읽어오기
        Dictionary<string, string> dictVolumeValues = GameManager.instance.DataRead(_strGraphicValueFolderPath + _strGraphicValueFileName);
        //_fMasterVolume = float.Parse(dictVolumeValues["MasterVolume"]);
    }
    private void WriteValues()
    {
        Dictionary<string, string> dictVolumeValues = new();
        dictVolumeValues.Add("", ".ToString()");


        GameManager.instance.DataWrite(_strGraphicValueFolderPath + _strGraphicValueFileName, dictVolumeValues);
    }
    
}
