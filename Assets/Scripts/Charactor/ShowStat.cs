using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStat : MonoBehaviour
{
    [SerializeField]
    List<Text> Statlist;
    [SerializeField]
    Detail detail;

    void Start()
    {

        Debug.Log(transform.GetChild(0).GetChild(0).childCount);
        Debug.Log(detail.lOwn.Count);

        for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
        {
            Statlist.Add(transform.GetChild(0).GetChild(0).GetChild(i).gameObject.GetComponent<Text>());
        }
        
            for (int i = 0; i < Statlist.Count; i++)
            {
                Debug.Log($"{Statlist[i].name}");
               Statlist[i].text = Statlist[i].name + ":" + detail.lOwn[0][Statlist[i].name];
            }
       
    }

	
    
    

	// Update is called once per frame
	void Update()
    {
        
    }
}
