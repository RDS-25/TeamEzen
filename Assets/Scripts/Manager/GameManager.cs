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


    public GameObject[] arrCurCharacters = new GameObject[3];
    public float[] fCharid = new float[3];
    private bool _bTargetingDistance = false;

    public StageParams.STAGE_TYPE stageType = StageParams.STAGE_TYPE.NONE;

    public bool bTargetingDistance { get { return _bTargetingDistance; } set { _bTargetingDistance = value; } }

    public ObjectFactory objectFactory = new ObjectFactory();

    void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        Init();
        objectFactory.InitFactory();
        SetTargeting(_bTargetingDistance);
        SetCharObj();
    }
    private void FolderInit()
    {
        if (!FolderExists(FolderPath.MAIN_ROOT))
            CreateFoler(FolderPath.MAIN_ROOT);
        if (!FolderExists(FolderPath.PARAMS))
            CreateFoler(FolderPath.PARAMS);

        if (!FolderExists(FolderPath.PARAMS_GAMEMANAGER))
            CreateFoler(FolderPath.PARAMS_GAMEMANAGER);
        if (!FolderExists(FolderPath.PARAMS_GRAPHIC))
            CreateFoler(FolderPath.PARAMS_GRAPHIC);
        if (!FolderExists(FolderPath.PARAMS_SOUND))
            CreateFoler(FolderPath.PARAMS_SOUND);

        if (!FolderExists(FolderPath.PARAMS_SKILL))
            CreateFoler(FolderPath.PARAMS_SKILL);
        if (!FolderExists(FolderPath.PARAMS_ACTIVE_SKILL))
            CreateFoler(FolderPath.PARAMS_ACTIVE_SKILL);
        if (!FolderExists(FolderPath.PARAMS_PASSIVE_SKILL))
            CreateFoler(FolderPath.PARAMS_PASSIVE_SKILL);
        if (!FolderExists(FolderPath.PARAMS_ULTIMATE_SKILL))
            CreateFoler(FolderPath.PARAMS_ULTIMATE_SKILL);
        if (!FolderExists(FolderPath.PARAMS_COMMON_SKILL))
            CreateFoler(FolderPath.PARAMS_COMMON_SKILL);

        if (!FolderExists(FolderPath.PARAMS_CHARACTER))
            CreateFoler(FolderPath.PARAMS_CHARACTER);
        if (!FolderExists(FolderPath.PARAMS_MONSTER))
            CreateFoler(FolderPath.PARAMS_MONSTER);

        if (!FolderExists(FolderPath.PARAMS_ITEM))
            CreateFoler(FolderPath.PARAMS_ITEM);
        if (!FolderExists(FolderPath.PARAMS_ITEM_COUNT))
            CreateFoler(FolderPath.PARAMS_ITEM_COUNT);
    }
    private void Init()
    {
        FolderInit();
        _strGameManagerFolderPath = FolderPath.PARAMS_GAMEMANAGER;
        _strGameManagerFileName = FileName.STR_GAME_MANAGER;
        if (GameManager.instance.CheckExist(_strGameManagerFolderPath, _strGameManagerFileName))
            ReadValues();
        else
        {
            WriteValues();
            ReadValues();
        }

    }

    private void ReadValues()
    {
        Dictionary<string, string> dictTemp = DataRead(FolderPath.PARAMS_GAMEMANAGER + FileName.STR_GAME_MANAGER);
        bTargetingDistance = Convert.ToBoolean(dictTemp["TargetingDistance"]);
        fCharid[0] = float.Parse(dictTemp["FirstCharacterId"]);
        fCharid[1] = float.Parse(dictTemp["SecondCharacterId"]);
        fCharid[2] = float.Parse(dictTemp["ThirdCharacterId"]);
    }
    private void WriteValues()
    {
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("TargetingDistance", bTargetingDistance.ToString());
        dictTemp.Add("FirstCharacterId", fCharid[0].ToString());
        dictTemp.Add("SecondCharacterId", fCharid[1].ToString());
        dictTemp.Add("ThirdCharacterId", fCharid[2].ToString());
        DataWrite(FolderPath.PARAMS_GAMEMANAGER + FileName.STR_GAME_MANAGER, dictTemp);
    }
    public void SetTargeting(bool bTargeting)
    {
        bTargetingDistance = bTargeting;
        WriteValues();
    }
    public void SetCharId(int index, float fId)
    {
        fCharid[index] = fId;
        WriteValues();
    }
    private void SetCharObj()
    {
        for(int i = 0; i < arrCurCharacters.Length; i++)
        {
            if(fCharid[i] != -1)
            {
                foreach(GameObject obj in objectFactory.characterFactory.listPool)
                {
                    if(fCharid[i] == obj.GetComponent<Stat>().fId)
                    {
                        arrCurCharacters[i] = obj;
                    }
                }
            }
        }
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
    public void ReWrite(string sFolderPathFileNameJson, Dictionary<string, string> dictNew)
    {
        Dictionary<string, string> dictTemp = DataRead(sFolderPathFileNameJson + ".json");
        foreach(KeyValuePair<string,string> keyValuePair in dictNew)
        {
            if (!dictTemp.ContainsKey(keyValuePair.Key))
            {
                dictTemp.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }
        DataWrite(sFolderPathFileNameJson + ".json", dictTemp);
    }
    public Sprite LoadAndSetSprite(string imagePath)
    {
        string path = Application.dataPath + Path.Combine(imagePath);
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
    //폴더 확인
    public bool CheckExist(string sFolderPath, string sFileName)
    {
        //폴더 있나 확인  없으면 생성
        if (!FolderExists(sFolderPath))
            CreateFoler(sFolderPath);
        if (FileExists(sFolderPath + sFileName+".json"))
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
