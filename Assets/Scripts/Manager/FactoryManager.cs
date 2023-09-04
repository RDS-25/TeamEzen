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

    // �޸�Ǯ ���� Resources/ �� ���� ��� + ���ϸ� �־��ֱ�
    public void CreateFactory(string sPrefabPathPrefabName, int nSize)
    {
        if (isCreate == true)
        {
            Debug.Log("�̹� �����մϴ�.");
            return;
        }
        isCreate = true;
        _gPrefab = Resources.Load<GameObject>(sPrefabPathPrefabName);
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
        _gPrefabs = Resources.LoadAll<GameObject>(sFolderPath);
        CreateObject(_gPrefabs);
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
        if(gPrefab == null)
        {
            Debug.LogError("���ӿ�����Ʈ�� �����ϴ�.");
            return null;
        }
        GameObject gNewObj = GameObject.Instantiate(gPrefab, GameManager.instance.gameObject.transform.GetChild(0));
        gNewObj.name = gNewObj.name.Replace("(Clone)", "").Trim();
        listPool.Add(gNewObj);
        gNewObj.SetActive(false);
        return gNewObj;
    }
    // ������Ʈ ������ �޾Ƽ� ������ ����
    public void CreateObject(GameObject gPrefab, int nSize)
    {
        if (gPrefab == null)
        {
            Debug.LogError("���ӿ�����Ʈ�� �����ϴ�.");
        }
        for (int i = 0; i < nSize; i++)
        {
            CreateObject(gPrefab);
        }
    }
    // ������Ʈ �迭�� �޾Ƽ� �ϳ��� ����
    public void CreateObject(GameObject[] gPrefabs)
    {
        if (gPrefabs == null)
        {
            Debug.LogError("���ӿ�����Ʈ�� �����ϴ�.");
        }
        foreach (GameObject gPrefab in gPrefabs)
        {
            CreateObject(gPrefab);
           
        }
    }
    // �ڽ��� ������ �迭���� �ش� ��ȣ�� ������ ����
    public void CreateObject(int nPrefabNum)
    {
        if (_gPrefabs == null)
        {
            Debug.LogError("������ ����Ʈ�� �������� �ʽ��ϴ�.");
            return;
        }
        CreateObject(_gPrefabs[nPrefabNum]);
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
        if(listPool.Count <= 0)
        {
            Debug.LogError("����Ʈ�� ����ֽ��ϴ�.");
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
