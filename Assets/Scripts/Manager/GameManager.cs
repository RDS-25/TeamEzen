using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;
using Params;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string _strGameManagerFolderPath;
    private string _strGameManagerFileName;

    private bool _bTargetingDistance = false;

    private float _fFirstCharacterId = 0;
    private float _fSecondCharacterId = -1;
    private float _fThirdCharacterId = -1;

    public StageParams.STAGE_TYPE stageType = StageParams.STAGE_TYPE.NONE;

    public List<GameObject> listCurCharacters = new();

    public List<int> listCurCharId = new();

    public bool bTargetingDistance { get { return _bTargetingDistance; } set { _bTargetingDistance = value; } }
    public float fFirstCharacterId { get { return _fFirstCharacterId; } set { _fFirstCharacterId = value; } }
    public float fSecondCharacterId { get { return _fSecondCharacterId; } set { _fSecondCharacterId = value; } }
    public float fThirdCharacterId { get { return _fThirdCharacterId; } set { _fThirdCharacterId = value; } }


    public ObjectFactory objectFactory = new ObjectFactory();

    void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion
        FolderInit();
        Init();
        objectFactory.InitFactory();
        objectFactory.SelectCharacterInit();
    }
    void FolderInit()
    {
        if (!FolderExists("Assets/Resources/" + FolderPath.PREFABS))
            CreateFoler("Assets/Resources/" + FolderPath.PREFABS);
        if (!FolderExists(FolderPath.PARAMS))
            CreateFoler(FolderPath.PARAMS);
    }

    // Initialize
    private void Init()
    {
        // 폴더경로
        _strGameManagerFolderPath = FolderPath.PARAMS_GAMEMANAGER;
        // 파일경로
        _strGameManagerFileName = FileName.STR_GAME_MANAGER;
        // 파일이 이미있다면 그파일 데이터 읽기, 아니면 초기값 설정
        if (GameManager.instance.CheckExist(_strGameManagerFolderPath, _strGameManagerFileName))
            ReadValues();
        else
            WriteValues();
        SetFirstChar(fFirstCharacterId);
        SetSecondChar(fSecondCharacterId);
        SetThirdChar(fThirdCharacterId);
        SetTargeting(bTargetingDistance);
        // 여러 데이터를 긁어와야대는데?
        // 게임매니저 파람스 필요

        // 아직 잘 모르겠음
    }

    private void ReadValues()
    {
        Dictionary<string, string> dictTemp = DataRead(FolderPath.PARAMS_GAMEMANAGER + FileName.STR_GAME_MANAGER);
        bTargetingDistance  = Convert.ToBoolean(dictTemp["TargetingDistance"]);
        fFirstCharacterId   =  float.Parse(dictTemp["FirstCharacterId"]);
        fSecondCharacterId  = float.Parse(dictTemp["SecondCharacterId"]);
        fThirdCharacterId   = float.Parse(dictTemp["ThirdCharacterId"]);
    }
    private void WriteValues()
    {
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("TargetingDistance",   bTargetingDistance.ToString());
        dictTemp.Add("FirstCharacterId",    fFirstCharacterId.ToString());
        dictTemp.Add("SecondCharacterId",   fSecondCharacterId.ToString());
        dictTemp.Add("ThirdCharacterId",    fThirdCharacterId.ToString());
        DataWrite(FolderPath.PARAMS_GAMEMANAGER + FileName.STR_GAME_MANAGER, dictTemp);
    }
    public void SetTargeting(bool bTargeting)
    {
        bTargetingDistance = bTargeting;
        WriteValues();
    }
    public void SetFirstChar(float fId)
    {
        fFirstCharacterId = fId;
        WriteValues();
    }
    public void SetSecondChar(float fId)
    {
        fSecondCharacterId = fId;
        WriteValues();
    }
    public void SetThirdChar(float fId)
    {
        fThirdCharacterId = fId;
        WriteValues();
    }

    // DataRead
    // 데이터 주소 받아와서 그 주소의 json 파일을 Dictionary 형태로 데이터 반환
    public Dictionary<string, string> DataRead(string sFolderPathFileNameJson)
    {
        try
        {
            // 임시 변수 선언, 경로의 파일 읽어오기
            string sData = File.ReadAllText(sFolderPathFileNameJson + ".json");
            // 임시 Dictionary 선언 Newtonsoft.json 의 클래스를 사용해 json을 Dictionary로 바꿈
            Dictionary<string, string> dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary 반환
            return dictResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]에서 데이터 읽기에 실패하였습니다.{ex}");
            return null;
        }
    }
    // 폴더 안의 json 데이터 전부 읽어오기
    public List<Dictionary<string,string>> DataReadAll(string sFolderPath)
    {
        try
        {
            List<Dictionary<string, string>> listTemp = new List<Dictionary<string, string>>();
            string[] arrTemp = Directory.GetFiles(sFolderPath);
            foreach(string sJsonPath in arrTemp)
            {
                string sData = File.ReadAllText(sJsonPath);
                Dictionary<string, string> dictTemp = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
                listTemp.Add(dictTemp);
            }
            return listTemp;
        }
        catch( Exception ex)
        {
            Debug.LogError($"[{sFolderPath}]에서 데이터 읽기에 실패하였습니다.{ex}");
            return null;
        }
    }
    // DataWrite
    // 데이터 주소와 Dictionary 형태로 데이터를 받아와 json 파일로 저장
    public void DataWrite(string sFolderPathFileNameJson, Dictionary<string, string> dictData)
    {
        try
        {
            // Newtonsoft.json 의 클래스를 사용해 Dictionay를 json으로 바꿈
            string sJson = JsonConvert.SerializeObject(dictData);
            
            // 경로에 json 파일 저장
            File.WriteAllText(sFolderPathFileNameJson + ".json", sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]에 데이터 쓰기에 실패하였습니다.{ex}");
        }
    }
    public string GetValue(string sFolderPathFileNameJson, string sKey)
    {
        Dictionary<string, string> dictTemp = DataRead(sFolderPathFileNameJson + ".json");
        if (dictTemp.ContainsKey(sKey))
        {
            return dictTemp[sKey];
        }
        else
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]에 키값 존재하지 않음");
            return null;
        }
    }
    public void WriteKeyValue(string sFolderPathFileNameJson, string sKey, string sValue)
    {
        Dictionary<string, string> dictTemp = DataRead(sFolderPathFileNameJson + ".json");
        if (dictTemp.ContainsKey(sKey))
        {
            dictTemp[sKey] = sValue;
            DataWrite(sFolderPathFileNameJson + ".json", dictTemp);
        }
        else
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]에 키값 존재하지 않음");
        }
    }
    public Sprite LoadAndSetSprite(string imagePath)
    {
        string path = Path.Combine(imagePath);
        if (File.Exists(path))
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(imageBytes))
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError("Failed to load image: " + imagePath);
                return null;
            }
        }
        else
        {
            Debug.LogError("Image file not found: " + path);
            return null;
        }
    }

    //string NAME
    //{
    //    get 
    //    {
    //        return LoadFild("name");
    //    }
    //    set
    //    {
    //        saveFile("key", value);
    //    }
    //}

    //폴더 확인
    public bool CheckExist(string sFolderPath, string sFileName)
    {
        //폴더 있나 확인  없으면 생성
        if (!FolderExists(sFolderPath))
            CreateFoler(sFolderPath);
        if (FileExists(sFolderPath + sFileName + ".json"))
            return true;
        else
            return false;
    }
    // 파일 존재 체크
    public bool FileExists(string sFolderPathFileNameJson)
    {
        return File.Exists(sFolderPathFileNameJson);
    }
    // 폴더 존재 체크
    public bool FolderExists(string sFolderPath)
    {
        return Directory.Exists(sFolderPath);
    }
    // 폴더 만들기
    public void CreateFoler(string sFolderPath)
    {
        Directory.CreateDirectory(sFolderPath);
    }


}
