using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Detail : MonoBehaviour
{
    public TMP_Text TName;
    public TMP_Text TLevel;
    public TMP_Text THp; 
    public TMP_Text TAtk;
    public TMP_Text TDef;
    public TMP_Text TCritiper;
 

    public GameObject select;

    public SelectCharactorUIManager gSelectCharM;


	private void Update()
	{
        GameObject curChar = GameManager.instance.objectFactory.ownCharFactory.listPool[gSelectCharM.curCharID];
        //현재 선택된 캐릭터 정보  보여주기 

        TName.text     = curChar.GetComponent<Stat>().strName; 
        TLevel.text     = curChar.GetComponent<Stat>().fLevel.ToString(); 
        THp.text        = curChar.GetComponent<Stat>().fHealth.ToString();
        TAtk.text       = curChar.GetComponent<Stat>().fAtk.ToString();
        TDef.text       = curChar.GetComponent<Stat>().fDef.ToString();
        TCritiper.text  = curChar.GetComponent<Stat>().fCriticalPer.ToString();

    }

}
