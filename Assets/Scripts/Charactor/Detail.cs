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
        //현재 선택된 캐릭터 정보  보여주기 

        TLevel.text ="레벨 :" + curChar.GetComponent<Stat>().fLevel; 
        THp.text ="체력 :"+ curChar.GetComponent<Stat>().fHealth;
        TAtk.text = "공격력 :" + curChar.GetComponent<Stat>().fAtk; 
        TDef.text = "방어력 :" + curChar.GetComponent<Stat>().fDef; 
        TCritiper.text = "크티리컬 확률 :" + curChar.GetComponent<Stat>().fCriticalPer;

    }

}
