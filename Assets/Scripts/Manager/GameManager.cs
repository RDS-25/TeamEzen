using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;

#region Ÿ�Ӷ���
/*20230809
 * Dictionary<string, string> DataRead(string sPath)
 * json ������ �о���� ����
 * public void DataWrite(string sPath, Dictionary<string, string> dicData)
 * Dictionary ������ json �����ͷ� ����
 */
/*20230810
 * DataRead DataWrite�� try catch �߰�
 */
/* 20230814
 * 
 * 
 * 
 */
/* 20230816
 * public string GetValue(string sPath, string sKey)
 * json ���Ͽ��� Ű ���� �ش��ϴ� ���� ��������
 * public bool FileExists(string sPath)
 * ���� �����ϴ��� üũ
 * public bool FolderExists(string sPath)
 * ���� �����ϴ��� üũ
 * public void CreateFoler(string sPath)
 * ���� �����
 */
/*
�߰��ؾ��� ���
���� ���۽� ���� ������ Ȯ�� -> ����� ��ȴ���, ������Ʈ �Ǿ�����
************ �߿�
���� ������ ������ ����������?   ĳ���� ���ð� ��ų ���ð� ���
ĳ���� ���� ����
���� ����
���� ����
��ų ���� ����

CurrentState ���� ���� �������� ������ �־���ҵ�
************
���� ���۽� ������ ����� ������ �ʱ�ȭ �߰�
�ε� �� �߰�
�ε� ��� �߰�
Ÿ��Ʋ, �κ�, ��� ��� ������ Ȯ��
�ӽ����� ����
��� �������̽�
*/
#endregion
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // ���ӸŴ��� �Ķ��� �����ߵ�
    private string _sGameId;
    private string _sFirstCharacterId;
    private string _sSecondCharacterId;
    private string _sThirdCharacterId;
    public string sGameId { get; }


    
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
    }
    void Start()
    {
    }
    // Initialize
    private void InitalizeGameData(string sId)
    {
        // ������ �����ϴ��� Ȯ���ؾ���
        // ������ ���̽����� �ܾ�ͼ� �ʱ�ȭ
        // ������ ���̽��� ������ json ������ �ܾ�ͼ� �ʱ�ȭ
        DataRead("");
        // ���� �����͸� �ܾ�;ߴ�µ�?
        // ���ӸŴ��� �Ķ��� �ʿ�

        // ���� �� �𸣰���
    }
    // DataRead
    // ������ �ּ� �޾ƿͼ� �� �ּ��� json ������ Dictionary ���·� ������ ��ȯ
    public Dictionary<string, string> DataRead(string sPath)
    {
        try
        {
            // �ӽ� ���� ����, ����� ���� �о����
            string sData = File.ReadAllText(sPath);
            // �ӽ� Dictionary ���� Newtonsoft.json �� Ŭ������ ����� json�� Dictionary�� �ٲ�
            Dictionary<string, string> dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary ��ȯ
            return dictResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPath}]���� ������ �б⿡ �����Ͽ����ϴ�.{ex}");
            return null;
        }
    }
    // DataWrite
    // ������ �ּҿ� Dictionary ���·� �����͸� �޾ƿ� json ���Ϸ� ����
    public void DataWrite(string sPath, Dictionary<string, string> dictData)
    {
        try
        {
            // Newtonsoft.json �� Ŭ������ ����� Dictionay�� json���� �ٲ�
            string sJson = JsonConvert.SerializeObject(dictData);
            // ��ο� json ���� ����
            File.WriteAllText(sPath, sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPath}]�� ������ ���⿡ �����Ͽ����ϴ�.{ex}");
        }
    }
    public string GetValue(string sPath, string sKey)
    {
        Dictionary<string, string> dictTemp = DataRead(sPath);
        if (dictTemp.ContainsKey(sKey))
        {
            return dictTemp[sKey];
        }
        else
        {
            Debug.LogError($"[{sPath}]�� Ű�� �������� ����");
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
    public bool FileExists(string sPath)
    {
        return File.Exists(sPath);
    }
    // ���� ���� üũ
    public bool FolderExists(string sPath)
    {
        return Directory.Exists(sPath);
    }
    // ���� �����
    public void CreateFoler(string sPath)
    {
        Directory.CreateDirectory(sPath);
    }
}

#region �׽�Ʈ
/*
        string path = Application.persistentDataPath + "/";
        string filename = "testFile.json";
        Dictionary<string, string> test = new Dictionary<string, string>();
        test.Add("level", "1");
        test.Add("name", "test");
        test.Add("attack", "12");
        test.Add("hp", "10");

        DataWrite(path + filename, test);

        Dictionary<string, string> RoadData = DataRead(path + filename);

        foreach (string value in RoadData.Keys)
        {
            Debug.Log("Key : " + value + " value : " + RoadData[value]);
        }

        Debug.Log(DataRead(path + filename)); 
*/
#endregion