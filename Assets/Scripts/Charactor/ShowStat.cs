using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowStat : MonoBehaviour
{
    [SerializeField]
    List<TMP_Text> Statlist;
    [SerializeField]
    Detail detail;


    List<Dictionary<string, string>> AllChar;


    Dictionary<string, string> curDic;


    void Start()
    {
        AllChar = GameManager.instance.DataReadAll(FolderPath.PARAMS_CHARACTER);
      
        for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
        {
            Statlist.Add(transform.GetChild(0).GetChild(0).GetChild(i).GetChild(2).gameObject.GetComponent<TMP_Text>());
        }
    }

	// Update is called once per frame
	void Update()
    {
        GameObject curChar = GameManager.instance.objectFactory.ownCharFactory.listPool[detail.gSelectCharM.curCharID];
    

        for (int i = 0; i < AllChar.Count; i++)
        {
            if (int.Parse(AllChar[i][CharPath.ID]) == curChar.GetComponent<Stat>().fId)
            {
                curDic = AllChar[i];
            }
        }

        for (int i = 0; i < Statlist.Count; i++)
        {
            Statlist[i].text = curDic[Statlist[i].gameObject.name];
        }

    }
}
