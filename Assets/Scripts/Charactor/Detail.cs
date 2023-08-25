using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public CharactorSelect cSelect;

    //리스트는 초기화를 무조건해주기
    [SerializeField]
     List<Dictionary<string,string>> lJson = new List<Dictionary<string, string>>();
    [SerializeField]
     List<Dictionary<string, string>> lOwn = new List<Dictionary<string, string>>();

    void Start()
    {
        //JSON데이터 전부 읽어오기
        lJson = GameManager.instance.DataReadAll(cSelect._sFolderPath);
  
        //lJSON길이만큼   돌려주기
        for (int i = 0; i < lJson.Count; i++) {
         //cSelect만큼 돌려주기
            for (int j = 0; j < cSelect.L_ID.Count; j++)
            {
                //확인해서 같으면 추가하기
                if (int.Parse(lJson[i]["ID"]) == int.Parse(cSelect.L_ID[j]))
                {
                    lOwn.Add(lJson[i]);
             
                }
            }
        }
    }

}
