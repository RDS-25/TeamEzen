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
   


    //����Ʈ�� �ʱ�ȭ�� ���������ֱ�
    [SerializeField]
     List<Dictionary<string,string>> lJson = new List<Dictionary<string, string>>();
    [SerializeField]
    public List<Dictionary<string, string>> lOwn = new List<Dictionary<string, string>>();

    void Start()
    {
        

        //JSON������ ���� �о����
        lJson = GameManager.instance.DataReadAll(select.GetComponent<CharactorSelect>()._sFolderPath);

       
        //lJSON���̸�ŭ   �����ֱ�
        for (int i = 0; i < lJson.Count; i++) {
         //cSelect��ŭ �����ֱ�
            for (int j = 0; j < select.GetComponent<CharactorSelect>().L_ID.Count; j++)
            {
                //Ȯ���ؼ� ������ �߰��ϱ�
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

        //���� ���õ� ĳ���� ����  �����ֱ� 
        /*
        TLevel.text ="���� :"+lOwn[0][CharPath.LEVEL];
        THp.text ="ü�� :"+lOwn[0][CharPath.HEALTH];
        TAtk.text = "���ݷ� :" + lOwn[0][CharPath.ATK];
        TDef.text = "���� :" + lOwn[0][CharPath.DEF];
        TCritiper.text = "ũƼ���� Ȯ�� :" + lOwn[0][CharPath.CRITIPER];
        */
    }

}
