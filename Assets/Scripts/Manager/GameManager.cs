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
/* 20230821
 * public List<Dictionary<string,string>> DataReadAll(string sFolderPath)
 * ���� ���� json ���� �����а� list<dictionary<stirng,string>> ���·� ��ȯ
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
        // ������ ���丮 ���� ��������?

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
    public Dictionary<string, string> DataRead(string sPathFileName)
    {
        try
        {
            // �ӽ� ���� ����, ����� ���� �о����
            string sData = File.ReadAllText(sPathFileName);
            // �ӽ� Dictionary ���� Newtonsoft.json �� Ŭ������ ����� json�� Dictionary�� �ٲ�
            Dictionary<string, string> dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(sData);
            //Dictionary ��ȯ
            return dictResult;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPathFileName}]���� ������ �б⿡ �����Ͽ����ϴ�.{ex}");
            return null;
        }
    }
    // ���� ���� json ������ ���� �о����
    public List<Dictionary<string,string>> DataReadAll(string sFolderPath)
    {
        try
        {
            List<Dictionary<string, string>> listTemp = null;
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
    public void DataWrite(string sPathFileName, Dictionary<string, string> dictData)
    {
        try
        {
            // Newtonsoft.json �� Ŭ������ ����� Dictionay�� json���� �ٲ�
            string sJson = JsonConvert.SerializeObject(dictData);
            // ��ο� json ���� ����
            File.WriteAllText(sPathFileName, sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sPathFileName}]�� ������ ���⿡ �����Ͽ����ϴ�.{ex}");
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
