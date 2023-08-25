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


    public CharactorSelect cSelect;

    SelectCharactorUIManager SelectCharactorUI;

    //����Ʈ�� �ʱ�ȭ�� ���������ֱ�
    [SerializeField]
     List<Dictionary<string,string>> lJson = new List<Dictionary<string, string>>();
    [SerializeField]
     List<Dictionary<string, string>> lOwn = new List<Dictionary<string, string>>();

    void Start()
    {
        //JSON������ ���� �о����
        lJson = GameManager.instance.DataReadAll(cSelect._sFolderPath);
  
        //lJSON���̸�ŭ   �����ֱ�
        for (int i = 0; i < lJson.Count; i++) {
         //cSelect��ŭ �����ֱ�
            for (int j = 0; j < cSelect.L_ID.Count; j++)
            {
                //Ȯ���ؼ� ������ �߰��ϱ�
                if (int.Parse(lJson[i]["ID"]) == int.Parse(cSelect.L_ID[j]))
                {
                    lOwn.Add(lJson[i]);
                }
               
            }
        }
    }

	private void Update()
	{
        /*
        TLevel.text ="���� :"+lOwn[0][CharPath.LEVEL];
        THp.text ="ü�� :"+lOwn[0][CharPath.HEALTH];
        TAtk.text = "���ݷ� :" + lOwn[0][CharPath.ATK];
        TDef.text = "���� :" + lOwn[0][CharPath.DEF];
        TCritiper.text = "ũƼ���� Ȯ�� :" + lOwn[0][CharPath.CRITIPER];
        */
    }

}
