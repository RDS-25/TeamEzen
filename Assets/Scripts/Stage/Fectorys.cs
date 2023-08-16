using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fectories
{
    public class ObjectFectory
    {
        private int nObjectMaxCount = 0;
        private GameObject _objPrefab;
        private GameObject[] _objPrefabs;
        public Queue<GameObject> prefabsQueue = new Queue<GameObject>();
        
        public ObjectFectory(string path, string name, int max_count)
        {
            nObjectMaxCount = max_count;
            _objPrefab = (GameObject)Resources.Load(path + "\\" + name);
            _objPrefabs = new GameObject[nObjectMaxCount];
            CreatePool();
        }

        private bool CreatePool()
        {
            if (_objPrefab != null)
            {
                for (int i = 0; i < nObjectMaxCount; i++)
                {
                    _objPrefabs[i] = MonoBehaviour.Instantiate(_objPrefab);
                    _objPrefabs[i].SetActive(false);
                    prefabsQueue.Enqueue(_objPrefabs[i]);
                }
                return true;
            }
            return false;
        }

        public void SetObject(GameObject value)
        {
            prefabsQueue.Enqueue(value);
        }
        public GameObject GetObject()
        {
            return prefabsQueue.Dequeue();
        }
    }
}
