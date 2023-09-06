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
        #region �̱���
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
        // �������
        _strGameManagerFolderPath = FolderPath.PARAMS_GAMEMANAGER;
        // ���ϰ��
        _strGameManagerFileName = FileName.STR_GAME_MANAGER;
        // ������ �̹��ִٸ� ������ ������ �б�, �ƴϸ� �ʱⰪ ����
        if (GameManager.instance.CheckExist(_strGameManagerFolderPath, _strGameManagerFileName))
            ReadValues();
        else
            WriteValues();
        SetFirstChar(fFirstCharacterId);
        SetSecondChar(fSecondCharacterId);
        SetThirdChar(fThirdCharacterId);
        SetTargeting(bTargetingDistance);
        // ���� �����͸� �ܾ�;ߴ�µ�?
        // ���ӸŴ��� �Ķ��� �ʿ�

        // ���� �� �𸣰���
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
    // ������ �ּ� �޾ƿͼ� �� �ּ��� json ������ Dictionary ���·� ������ ��ȯ
    public Dictionary<string, string> DataRead(string sFolderPathFileNameJson)
    {
        try
        {
            // �ӽ� ���� ����, ����� ���� �о����
            string sData = File.ReadAllText(sFolderPathFileNameJson + ".json");
            // �ӽ� Dictionary ���� Newtonsoft.json �� Ŭ������ ����� json�� Dictionary�� �ٲ�
            Dictionary<string, string> dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary ��ȯ
            return dictResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]���� ������ �б⿡ �����Ͽ����ϴ�.{ex}");
            return null;
        }
    }
    // ���� ���� json ������ ���� �о����
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
            Debug.LogError($"[{sFolderPath}]���� ������ �б⿡ �����Ͽ����ϴ�.{ex}");
            return null;
        }
    }
    // DataWrite
    // ������ �ּҿ� Dictionary ���·� �����͸� �޾ƿ� json ���Ϸ� ����
    public void DataWrite(string sFolderPathFileNameJson, Dictionary<string, string> dictData)
    {
        try
        {
            // Newtonsoft.json �� Ŭ������ ����� Dictionay�� json���� �ٲ�
            string sJson = JsonConvert.SerializeObject(dictData);
            
            // ��ο� json ���� ����
            File.WriteAllText(sFolderPathFileNameJson + ".json", sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]�� ������ ���⿡ �����Ͽ����ϴ�.{ex}");
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
            Debug.LogError($"[{sFolderPathFileNameJson}]�� Ű�� �������� ����");
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
            Debug.LogError($"[{sFolderPathFileNameJson}]�� Ű�� �������� ����");
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

    //���� Ȯ��
    public bool CheckExist(string sFolderPath, string sFileName)
    {
        //���� �ֳ� Ȯ��  ������ ����
        if (!FolderExists(sFolderPath))
            CreateFoler(sFolderPath);
        if (FileExists(sFolderPath + sFileName + ".json"))
            return true;
        else
            return false;
    }
    // ���� ���� üũ
    public bool FileExists(string sFolderPathFileNameJson)
    {
        return File.Exists(sFolderPathFileNameJson);
    }
    // ���� ���� üũ
    public bool FolderExists(string sFolderPath)
    {
        return Directory.Exists(sFolderPath);
    }
    // ���� �����
    public void CreateFoler(string sFolderPath)
    {
        Directory.CreateDirectory(sFolderPath);
    }


}
