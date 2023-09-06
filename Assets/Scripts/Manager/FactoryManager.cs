using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager
{
    bool isCreate = false;
    private GameObject _gPrefab;
    private GameObject[] _gPrefabs;

    public List<GameObject> listPool = new List<GameObject>();

    public GameObject gPrefab { get { return _gPrefab; } }

    // 메모리풀 생성 Resources/ 이 다음 경로 + 파일명 넣어주기
    public void CreateFactory(string sPrefabPathPrefabName, int nSize)
    {
        if (isCreate == true)
        {
            Debug.Log("이미 존재합니다.");
            return;
        }
        isCreate = true;
        _gPrefab = Resources.Load<GameObject>(sPrefabPathPrefabName);
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
        _gPrefabs = Resources.LoadAll<GameObject>(sFolderPath);
        CreateObject(_gPrefabs);
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
        if(gPrefab == null)
        {
            Debug.LogError("게임오브젝트가 없습니다.");
            return null;
        }
        GameObject gNewObj = GameObject.Instantiate(gPrefab, GameManager.instance.gameObject.transform.GetChild(0));
        gNewObj.name = gNewObj.name.Replace("(Clone)", "").Trim();
        listPool.Add(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }
    // 오브젝트 사이즈 받아서 여러개 생성
    public void CreateObject(GameObject gPrefab, int nSize)
    {
        if (gPrefab == null)
        {
            Debug.LogError("게임오브젝트가 없습니다.");
        }
        for (int i = 0; i < nSize; i++)
        {
            CreateObject(gPrefab);
        }
    }
    // 오브젝트 배열을 받아서 하나씩 생성
    public void CreateObject(GameObject[] gPrefabs)
    {
        if (gPrefabs == null)
        {
            Debug.LogError("게임오브젝트가 없습니다.");
        }
        foreach (GameObject gPrefab in gPrefabs)
        {
            CreateObject(gPrefab);
           
        }
    }
    // 자신의 프리팹 배열에서 해당 번호의 프리팹 생성
    public void CreateObject(int nPrefabNum)
    {
        if (_gPrefabs == null)
        {
            Debug.LogError("프리팹 리스트가 존재하지 않습니다.");
            return;
        }
        CreateObject(_gPrefabs[nPrefabNum]);
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
        if(listPool.Count <= 0)
        {
            Debug.LogError("리스트가 비어있습니다.");
            return null;
        }
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
