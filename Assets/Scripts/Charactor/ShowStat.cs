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
    
    string _value = "";
    public string value
    {
        get { return _value;}
        set { _value = value; }
    }


    void Start()
    {

     
        GameObject curChar = detail.gSelectCharM.OwnChar[detail.gSelectCharM.curCharID];

        Debug.Log(transform.GetChild(0).GetChild(0).childCount);
   

        for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
        {
            Statlist.Add(transform.GetChild(0).GetChild(0).GetChild(i).gameObject.GetComponent<Text>());
        }
        Stat charStats = curChar.GetComponent<Stat>();



        for (int i = 0; i < Statlist.Count; i++)
        {
           curChar.GetComponent<Stat>().GetType().GetProperty("fId").GetValue(value);
           string a = value.ToString();
           Statlist[i].text = Statlist[i].name + ":"+ curChar.GetComponent<Stat>().GetType().GetProperty(Statlist[i].name).GetValue(GetComponent<Stat>()).ToString(); 
        }
       
       
    }

	
    
    

	// Update is called once per frame
	void Update()
    {
        
    }
}
