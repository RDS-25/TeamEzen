using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMangerTest : MonoBehaviour
{
    public List<GameObject> SelectedChar;
    public Transform curPos;
    public Transform curRot;
    public Transform curChar;

	private void Start()
	{
        SelectedChar = GameManager.instance.stageFactory.ownCharFactory.listPool;
        curPos = SelectedChar[0].transform;
        curRot = SelectedChar[0].transform;
        curChar = SelectedChar[0].transform;
	}

	void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            curPos = curChar;
            curRot = curChar;
            SelectedChar[0].SetActive(true);
            curChar = SelectedChar[0].transform;
            SelectedChar[0].transform.rotation = curRot.rotation;
            SelectedChar[0].transform.position = curPos.position;

  
            for (int i = 0; i < SelectedChar.Count; i++)
            {
                if (i != 0)
                {
                    SelectedChar[i].SetActive(false);
                }
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            curPos = curChar;
            curRot = curChar;
            SelectedChar[1].SetActive(true);
            curChar = SelectedChar[1].transform;
            SelectedChar[1].transform.rotation = curRot.rotation;
            SelectedChar[1].transform.position = curPos.position;

            for (int i = 0; i < SelectedChar.Count; i++)
            {
                if (i != 1)
                {
                    SelectedChar[i].SetActive(false);
                }
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (SelectedChar[2] != null) {
                SelectedChar[2].SetActive(true);
                for (int i = 0; i < SelectedChar.Count; i++)
                {
                    if (i != 2)
                    {
                        SelectedChar[i].SetActive(false);
                    }
                }
            }
        }
    }


}
