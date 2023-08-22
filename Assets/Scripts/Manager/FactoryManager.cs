using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region 타임라인
/*20230809
 * public void PoolConstruct(string path, int nSize)
 * public void PoolDeAllocate()
 * public GameObject GetObject(int nSize)
 * 큐 해제는 추가 구현 필요
 * get오브젝트 추가 구현 필요
 * get한 오브젝트 setActive false시 enqueue해주는 과정 필요
 */
/*20230810
 * 리스트 대신 Queue 사용
 * PoolConstruct -> public void CreateFactory(string sPath, int nSize)
 * 이름 바꿈, 메모리풀 생성, 게임오브젝트 타입으로 지정
 * PoolDeAllocate -> public void DeCreatePool()
 * 큐 클리어
 * private GameObject CreateObject(GameObject gPrefab)
 * 프리팹으로 게임 오브젝트 생성 반환
 * public GameObject GetObject()
 * Pool에서 DeQueue, 없다면 새로 생성
 * public void SetObject(GameObject gObj)
 * 사용 종료된 오브젝트 EnQueue
 * public void Init()
 * 프리팹 초기화, 큐 초기화
 */
/* 20230817
 * public void CreateObject(GameObject gPrefab)
 * public void CreateObject(GameObject gPrefab, int nSize)
 * CreateObject 오버로딩
 * public GameObject gPrefab { get { return _gPrefab; } }
 * 프리팹 get
 */
/* 20230818
 * quePool을 List로 변경
 * public void CreateFactory(string sPath)
 * path 의 프리팹 하나씩 전부 생성 오버로딩
 * public void CreateObject(GameObject[] gPrefabs)
 * 오브젝트 배열로 생성 오버로딩
 */
/* 20230821
 * public void CreateObject(int nPrefabNum)
 * 자신의 프리팹 배열에서 해당 번호의 프리팹 생성
 * public List<GameObject> GetObjects(int nSize)
 * 리스트 원하는 갯수 빼오기
 */
#endregion
public class FactoryManager
{
    bool isCreate = false;
    private GameObject _gPrefab;
    private GameObject[] _gCharacterPrefab;

    public List<GameObject> listPool = new List<GameObject>();

    public GameObject gPrefab { get { return _gPrefab; } }

    // 메모리풀 생성
    public void CreateFactory(string sPath, int nSize)
    {
        if (isCreate == true)
        {
            Debug.Log("이미 존재합니다.");
            return;
        }
        isCreate = true;
        _gPrefab = Resources.Load<GameObject>(sPath);
        CreateObject(_gPrefab, nSize);
    }
    // 메모리풀 생성 배열로 받아서 하나씩
    public void CreateFactory(string sFolderPath)
    {
        if (isCreate == true)
        {
            Debug.Log("이미 존재합니다.");
            return;
        }
        isCreate = true;
        _gCharacterPrefab = Resources.LoadAll<GameObject>(sFolderPath);
        CreateObject(_gCharacterPrefab);
    }
    // 메모리풀 소멸
    // 할당된 리스트 소멸해주는 함수
    public void DeCreatePool()
    {
        isCreate = false;
        listPool.Clear();
        listPool = null;
    }
    // 오브젝트 하나만 생성
    public GameObject CreateObject(GameObject gPrefab)
    {
        GameObject gNewObj = GameObject.Instantiate(gPrefab, GameManager.instance.gameObject.transform);
        gNewObj.name = gNewObj.name.Replace("(Clone)", "").Trim();
        listPool.Add(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }
    // 오브젝트 사이즈 받아서 여러개 생성
    public void CreateObject(GameObject gPrefab, int nSize)
    {
        for(int i = 0; i < nSize; i++)
        {
            CreateObject(gPrefab);
        }
    }
    // 오브젝트 배열을 받아서 하나씩 생성
    public void CreateObject(GameObject[] gPrefabs)
    {
        foreach(GameObject gPrefab in gPrefabs)
        {
            CreateObject(gPrefab);
        }
    }
    // 자신의 프리팹 배열에서 해당 번호의 프리팹 생성
    public void CreateObject(int nPrefabNum)
    {
        if (_gCharacterPrefab == null)
        {
            Debug.LogError("프리팹 리스트가 존재하지 않습니다.");
            return;
        }
        CreateObject(_gCharacterPrefab[nPrefabNum]);
    }
    // 오브젝트 리스트 맨뒤에서 하나씩 꺼내오기
    public GameObject GetObject()
    {
        
        if(listPool.Count > 0)
        {
            GameObject gObjInPool = listPool[^1];
            listPool.RemoveAt(listPool.Count - 1);
            return gObjInPool;
        }
        else
        {
            GameObject gNewObj = CreateObject(_gPrefab);
            return gNewObj;
        }
    }
    // 리스트 다빼오기
    public List<GameObject> GetObjectAll()
    {
        List<GameObject> listTemp = null;
        foreach(GameObject gObj in listPool)
        {
            listTemp.Add(gObj);
            listPool.Remove(gObj);
        }
        return listTemp;
    }
    // 원하는 리스트 번호 뽑기
    public GameObject GetObject(int nListNum)
    {
        if (listPool[nListNum] != null)
        {
            GameObject gObjInPool = listPool[nListNum];
            listPool.RemoveAt(nListNum);
            return gObjInPool;
        }
        else
        {
            Debug.LogError("해당 번호의 오브젝트가 존재하지 않습니다.");
            return null;
        }
    }
    // 리스트 원하는 갯수 빼오기
    public List<GameObject> GetObjects(int nSize)
    {
        if(listPool.Count < nSize)
        {
            Debug.Log("리스트의 남은 갯수가 더 적습니다.");
            return null;
        }
        List<GameObject> listTemp = null;
        for(int i = listPool.Count; i > listPool.Count - nSize; i--)
        {
            listTemp.Add(listPool[i]);
            listPool.RemoveAt(i);
        }
        return listTemp;
    }

    // 오브젝트 리스트 안으로 넣어주기
    public void SetObject(GameObject gObj)
    {
        gObj.SetActive(false);
        listPool.Add(gObj);
    }
}
