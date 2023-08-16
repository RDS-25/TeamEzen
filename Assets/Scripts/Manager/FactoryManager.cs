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
/*
추가해야할 기능
프리팹을 전역변수로 선언해야되나? -> 중요
CreateFactory 에서 지역변수로 선언해야하나?
*/
#endregion

public class FactoryManager : MonoBehaviour
{
    bool isCreate = false;
    private GameObject _gPrefab;
    private Queue<GameObject> quePool = new Queue<GameObject>();
    void Start()
    {
        Init();
    }
    // 이니셜라이즈
    public void Init()
    {
        _gPrefab = null;
        quePool.Clear();
    }
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
        for (int i = 0; i < nSize; i++)
        {
            CreateObject(_gPrefab);
        }
    }
    private GameObject CreateObject(GameObject gPrefab)
    {
        GameObject gNewObj = Instantiate(gPrefab, transform);
        quePool.Enqueue(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }
    // 메모리풀 소멸
    // 할당된 리스트 소멸해주는 함수
    public void DeCreatePool()
    {
        isCreate = false;
        quePool.Clear();
        quePool = null;
    }
    // 오브젝트 Queue에서 꺼내오기
    public GameObject GetObject()
    {
        if(quePool.Count > 0)
        {
            GameObject gObjInPool = quePool.Dequeue();
            gObjInPool.SetActive(true);
            return gObjInPool;
        }
        else
        {
            GameObject gNewObj = CreateObject(_gPrefab);
            Debug.Assert(gNewObj != null, "팩토리 먼저 만들기");
            gNewObj.SetActive(true);
            return gNewObj;
        }
    }
    // 오브젝트 Queue 안으로 넣어주기
    public void SetObject(GameObject gObj)
    {
        gObj.SetActive(false);
        quePool.Enqueue(gObj);
    }
}
