using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;

#region 타임라인
/*20230809
 * Dictionary<string, string> DataRead(string sPath)
 * json 데이터 읽어오기 구현
 * public void DataWrite(string sPath, Dictionary<string, string> dicData)
 * Dictionary 데이터 json 데이터로 저장
 */
/*20230810
 * DataRead DataWrite에 try catch 추가
 */
/* 20230814
 * 
 * 
 * 
 */
/* 20230816
 * public string GetValue(string sPath, string sKey)
 * json 파일에서 키 값에 해당하는 값만 가져오기
 * public bool FileExists(string sPath)
 * 파일 존재하는지 체크
 * public bool FolderExists(string sPath)
 * 폴더 존재하는지 체크
 * public void CreateFoler(string sPath)
 * 폴더 만들기
 */
/* 20230821
 * public List<Dictionary<string,string>> DataReadAll(string sFolderPath)
 * 폴더 내의 json 파일 전부읽고 list<dictionary<stirng,string>> 형태로 반환
 */
/*
추가해야할 기능
게임 시작시 게임 데이터 확인 -> 제대로 깔렸는지, 업데이트 되었는지
************ 중요
무슨 데이터 가지고 있을것인지?   캐릭터 선택값 스킬 선택값 등등
캐릭터 선택 정보
사운드 정보
계정 정보
스킬 선택 정보

CurrentState 같이 현재 정보들을 가지고 있어야할듯
************
게임 시작시 계정에 저장된 데이터 초기화 추가
로드 씬 추가
로딩 기능 추가
타이틀, 로비, 등등 어느 씬인지 확인
임시파일 생성
경로 인터페이스
*/
#endregion
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string _strGameManagerFolderPath;
    private string _strGameManagerFileName;
    // 게임매니저 파람스 만들어야됨
    private string _sGameId;
    private string _sFirstCharacterId;
    private string _sSecondCharacterId;
    private string _sThirdCharacterId;
    private string _sFirstSkillId;
    private string _sSecondSkillId;
    private string _sThirdSkillId;
    
    private List<Vector3> _listRoomPosition;

    private bool _bTargetingDistance;
    public bool bTargetingDistance { get { return _bTargetingDistance; } set { _bTargetingDistance = value; } }
    public string sGameId { get; }


    
    public StageFactory stageFactory = new StageFactory();

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
    }
    void Start()
    {
        if (!FolderExists(FolderPath.PREFABS))
            CreateFoler(FolderPath.PREFABS);
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
        DataRead("");
        // 여러 데이터를 긁어와야대는데?
        // 게임매니저 파람스 필요

        // 아직 잘 모르겠음
    }

    private void ReadValues()
    {

    }
    private void WriteValues()
    {

    }


    // DataRead
    // 데이터 주소 받아와서 그 주소의 json 파일을 Dictionary 형태로 데이터 반환
    public Dictionary<string, string> DataRead(string sFolderPathFileNameJson)
    {
        try
        {
            // 임시 변수 선언, 경로의 파일 읽어오기
            string sData = File.ReadAllText(sFolderPathFileNameJson);
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
            File.WriteAllText(sFolderPathFileNameJson, sJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{sFolderPathFileNameJson}]에 데이터 쓰기에 실패하였습니다.{ex}");
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
            Debug.LogError($"[{sFolderPathFileNameJson}]에 키값 존재하지 않음");
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
