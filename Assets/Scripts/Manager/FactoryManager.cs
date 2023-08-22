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
/* 20230821
 * public void CreateObject(int nPrefabNum)
 * �ڽ��� ������ �迭���� �ش� ��ȣ�� ������ ����
 * public List<GameObject> GetObjects(int nSize)
 * ����Ʈ ���ϴ� ���� ������
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
    public void CreateFactory(string sFolderPath)
    {
        if (isCreate == true)
        {
            Debug.Log("�̹� �����մϴ�.");
            return;
        }
        isCreate = true;
        _gCharacterPrefab = Resources.LoadAll<GameObject>(sFolderPath);
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
    // �ڽ��� ������ �迭���� �ش� ��ȣ�� ������ ����
    public void CreateObject(int nPrefabNum)
    {
        if (_gCharacterPrefab == null)
        {
            Debug.LogError("������ ����Ʈ�� �������� �ʽ��ϴ�.");
            return;
        }
        CreateObject(_gCharacterPrefab[nPrefabNum]);
    }
    // ������Ʈ ����Ʈ �ǵڿ��� �ϳ��� ��������
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
    // ����Ʈ �ٻ�����
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
    // ���ϴ� ����Ʈ ��ȣ �̱�
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
            Debug.LogError("�ش� ��ȣ�� ������Ʈ�� �������� �ʽ��ϴ�.");
            return null;
        }
    }
    // ����Ʈ ���ϴ� ���� ������
    public List<GameObject> GetObjects(int nSize)
    {
        if(listPool.Count < nSize)
        {
            Debug.Log("����Ʈ�� ���� ������ �� �����ϴ�.");
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

    // ������Ʈ ����Ʈ ������ �־��ֱ�
    public void SetObject(GameObject gObj)
    {
        gObj.SetActive(false);
        listPool.Add(gObj);
    }
}
