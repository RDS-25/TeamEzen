using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMangerTest : MonoBehaviour
{
    public List<GameObject> OwnChar;
    public Transform curPos;

	private void Start()
	{
       
	}

	void Update()
    {
        OwnChar = GameManager.instance.stageFactory.ownCharFactory.listPool;
 

        if (Input.GetKey(KeyCode.Alpha1))
        {
            
            OwnChar[0].SetActive(true);
            for (int i = 0; i < OwnChar.Count; i++)
            {
                if (i != 0)
                {
                    OwnChar[i].SetActive(false);
                }
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            
            OwnChar[1].SetActive(true);
            OwnChar[1].transform.position = curPos.position;
            
            for (int i = 0; i < OwnChar.Count; i++)
            {
                if (i != 1)
                {
                    OwnChar[i].SetActive(false);
                }
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (OwnChar[2] != null) {
                OwnChar[2].SetActive(true);
                for (int i = 0; i < OwnChar.Count; i++)
                {
                    if (i != 2)
                    {
                        OwnChar[i].SetActive(false);
                    }
                }
            }
        }
    }


}
