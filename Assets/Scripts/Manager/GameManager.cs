using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string _strGameManagerFolderPath;
    private string _strGameManagerFileName;

    private bool _bTargetingDistance = false;

    private float _fFirstCharacterId = -1;
    private float _fSecondCharacterId = -1;
    private float _fThirdCharacterId = -1;

    private float _fStageNumber = -1;

    public bool bTargetingDistance { get { return _bTargetingDistance; } set { _bTargetingDistance = value; } }
    public float fFirstCharacterId { get { return _fFirstCharacterId; } set { _fFirstCharacterId = value; } }
    public float fSecondCharacterId { get { return _fSecondCharacterId; } set { _fSecondCharacterId = value; } }
    public float fThirdCharacterId { get { return _fThirdCharacterId; } set { _fThirdCharacterId = value; } }
    public float fStageNumber { get { return _fStageNumber; } set { _fStageNumber = value; } }



    public StageFactory stageFactory = new StageFactory();

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
        if (!FolderExists("Assets/Resources/" + FolderPath.PREFABS))
            CreateFoler("Assets/Resources/" + FolderPath.PREFABS);
        if (!FolderExists(FolderPath.PARAMS))
            CreateFoler(FolderPath.PARAMS);
        Init();
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
            string sData = File.ReadAllText(sFolderPathFileNameJson);
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
            File.WriteAllText(sFolderPathFileNameJson, sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]�� ������ ���⿡ �����Ͽ����ϴ�.{ex}");
        }
    }
    public string GetValue(string sFolderPathFileNameJson, string sKey)
    {
        Dictionary<string, string> dictTemp = DataRead(sFolderPathFileNameJson);
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
        Dictionary<string, string> dictTemp = DataRead(sFolderPathFileNameJson);
        if (dictTemp.ContainsKey(sKey))
        {
            dictTemp[sKey] = sValue;
            DataWrite(sFolderPathFileNameJson, dictTemp);
        }
        else
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]�� Ű�� �������� ����");
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
    public bool CheckExist(string sFolderPath, string sFileName)
    {
        if (!FolderExists(sFolderPath))
            CreateFoler(sFolderPath);
        if (FileExists(sFolderPath + sFileName))
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
