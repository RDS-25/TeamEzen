using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region Ÿ�Ӷ���
/*20230809
 * public void PoolConstruct(string path, int nSize)
 * public void PoolDeAllocate()
 * public GameObject GetObject(int nSize)
 * ť ������ �߰� ���� �ʿ�
 * get������Ʈ �߰� ���� �ʿ�
 * get�� ������Ʈ setActive false�� enqueue���ִ� ���� �ʿ�
 */
/*20230810
 * ����Ʈ ��� Queue ���
 * PoolConstruct -> public void CreateFactory(string sPath, int nSize)
 * �̸� �ٲ�, �޸�Ǯ ����, ���ӿ�����Ʈ Ÿ������ ����
 * PoolDeAllocate -> public void DeCreatePool()
 * ť Ŭ����
 * private GameObject CreateObject(GameObject gPrefab)
 * ���������� ���� ������Ʈ ���� ��ȯ
 * public GameObject GetObject()
 * Pool���� DeQueue, ���ٸ� ���� ����
 * public void SetObject(GameObject gObj)
 * ��� ����� ������Ʈ EnQueue
 * public void Init()
 * ������ �ʱ�ȭ, ť �ʱ�ȭ
 */
/* 20230817
 * public void CreateObject(GameObject gPrefab)
 * public void CreateObject(GameObject gPrefab, int nSize)
 * CreateObject �����ε�
 * public GameObject gPrefab { get { return _gPrefab; } }
 * ������ get
 */
/* 20230818
 * quePool�� List�� ����
 * public void CreateFactory(string sPath)
 * path �� ������ �ϳ��� ���� ���� �����ε�
 * public void CreateObject(GameObject[] gPrefabs)
 * ������Ʈ �迭�� ���� �����ε�
 */
#endregion
public class FactoryManager
{
    bool isCreate = false;
    private GameObject _gPrefab;
    private GameObject[] _gCharacterPrefab;

    public List<GameObject> listPool = new List<GameObject>();

    public GameObject gPrefab { get { return _gPrefab; } }

    // �޸�Ǯ ����
    public void CreateFactory(string sPath, int nSize)
    {
        if (isCreate == true)
        {
            Debug.Log("�̹� �����մϴ�.");
            return;
        }
        isCreate = true;
        _gPrefab = Resources.Load<GameObject>(sPath);
        CreateObject(_gPrefab, nSize);
    }
    // �޸�Ǯ ���� �迭�� �޾Ƽ� �ϳ���
    public void CreateFactory(string sPath)
    {
        if (isCreate == true)
        {
            Debug.Log("�̹� �����մϴ�.");
            return;
        }
        isCreate = true;
        _gCharacterPrefab = Resources.LoadAll<GameObject>(sPath);
        CreateObject(_gCharacterPrefab);
    }
    // �޸�Ǯ �Ҹ�
    // �Ҵ�� ����Ʈ �Ҹ����ִ� �Լ�
    public void DeCreatePool()
    {
        isCreate = false;
        listPool.Clear();
        listPool = null;
    }
    // ������Ʈ �ϳ��� ����
    public GameObject CreateObject(GameObject gPrefab)
    {
        GameObject gNewObj = GameObject.Instantiate(gPrefab, GameManager.instance.gameObject.transform);
        gNewObj.name = gNewObj.name.Replace("(Clone)", "").Trim();
        listPool.Add(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }
    // ������Ʈ ������ �޾Ƽ� ������ ����
    public void CreateObject(GameObject gPrefab, int nSize)
    {
        for(int i = 0; i < nSize; i++)
        {
            CreateObject(gPrefab);
        }
    }
    // ������Ʈ �迭�� �޾Ƽ� �ϳ��� ����
    public void CreateObject(GameObject[] gPrefabs)
    {
        foreach(GameObject gPrefab in gPrefabs)
        {
            CreateObject(gPrefab);
        }
    }

    // ������Ʈ ����Ʈ �ǵڿ��� ��������
    // ���ϴ� ����Ʈ ��ȣ �̱�
    // ����Ʈ �ٻ�����
    // ����Ʈ ���ϴ� ���� ������
    public GameObject GetObject()
    {
        
        if(listPool.Count > 0)
        {
            GameObject gObjInPool = listPool[^1];
            // removeat�ʿ�
            return gObjInPool;
        }
        else
        {
            GameObject gNewObj = CreateObject(_gPrefab);
            return gNewObj;
        }
    }
    // ������Ʈ ����Ʈ ������ �־��ֱ�
    public void SetObject(GameObject gObj)
    {
        gObj.SetActive(false);
        listPool.Add(gObj);
    }


   
}
