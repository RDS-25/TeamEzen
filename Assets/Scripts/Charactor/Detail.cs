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
   


    //리스트는 초기화를 무조건해주기
    [SerializeField]
     List<Dictionary<string,string>> lJson = new List<Dictionary<string, string>>();
    [SerializeField]
    public List<Dictionary<string, string>> lOwn = new List<Dictionary<string, string>>();

    void Start()
    {
        

        //JSON데이터 전부 읽어오기
        lJson = GameManager.instance.DataReadAll(select.GetComponent<CharactorSelect>()._sFolderPath);

       
        //lJSON길이만큼   돌려주기
        for (int i = 0; i < lJson.Count; i++) {
         //cSelect만큼 돌려주기
            for (int j = 0; j < select.GetComponent<CharactorSelect>().L_ID.Count; j++)
            {
                //확인해서 같으면 추가하기
                if (int.Parse(lJson[i]["ID"]) == int.Parse(select.GetComponent<CharactorSelect>().L_ID[j]))
                {
                    lOwn.Add(lJson[i]);
                }
               
            }
        }
        for (int i = 0; i < lOwn.Count; i++) {
            Debug.Log(lOwn[i]["ID"]);
        }
    }

	private void Update()
	{

        //현재 선택된 캐릭터 정보  보여주기 
        /*
        TLevel.text ="레벨 :"+lOwn[0][CharPath.LEVEL];
        THp.text ="체력 :"+lOwn[0][CharPath.HEALTH];
        TAtk.text = "공격력 :" + lOwn[0][CharPath.ATK];
        TDef.text = "방어력 :" + lOwn[0][CharPath.DEF];
        TCritiper.text = "크티리컬 확률 :" + lOwn[0][CharPath.CRITIPER];
        */
    }

}
