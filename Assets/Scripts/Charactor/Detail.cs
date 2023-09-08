using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public Text TLevel;
    public Text THp; 
    public Text TAtk;
    public Text TDef;
    public Text TCritiper;
 

    public GameObject select;

    public SelectCharactorUIManager gSelectCharM;


	private void Update()
	{
        GameObject curChar = GameManager.instance.objectFactory.ownCharFactory.listPool[gSelectCharM.curCharID];
        Debug.Log(GameManager.instance.objectFactory.ownCharFactory.listPool.Count);
        //���� ���õ� ĳ���� ����  �����ֱ� 

        TLevel.text ="���� :" + curChar.GetComponent<Stat>().fLevel; 
        THp.text ="ü�� :"+ curChar.GetComponent<Stat>().fHealth;
        TAtk.text = "���ݷ� :" + curChar.GetComponent<Stat>().fAtk; 
        TDef.text = "���� :" + curChar.GetComponent<Stat>().fDef; 
        TCritiper.text = "ũƼ���� Ȯ�� :" + curChar.GetComponent<Stat>().fCriticalPer;

    }

}
