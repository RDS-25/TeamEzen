using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    ������ �����Ϳ� �ʱ�ȭ�� ������ ���ϴ� ����
    1.���� ĳ���͸� CharactorGroups ������Ʈ���� ���� ������ ��Ȱ��ȭ
    2.CharactorGroups ������Ʈ���� InitChar�� ����Ʈ���� �ֱ�
    3.���ÿ� ����� ������ �ִ� ĳ���� JSON �� InitChar�� �־�� ������Ʈ�� ��
    4.true�� Ȱ��ȭ�ؼ� �����ֱ� �״�� �α�
    
 */
public class CharactorSelect : MonoBehaviour
{

    //���� ������ �ִ� ĳ���� 
    //json���� ���� ���� (id, sprite)
    public List<Stat> Chacters;

    public List<GameObject> InitChar;

    //������ �������ִ� �θ� ������Ʈ
    [SerializeField]
    private Transform tSlotParent;
    //���� �迭
    [SerializeField]
    private Slot[] s_Slots;
    string a;
    string _sFolderPath;

    public List<string> L_ID;
    


	void Start()
    {

        _sFolderPath= Application.persistentDataPath + "/ParamsFolder/CharParams/";
        FreshSlot();
        L_ID = RoadChar(_sFolderPath);

        InitChar = GameManager.instance.stageFactory.characterFactory.listPool;
        addChar() ;
      
      /*  string a = Application.persistentDataPath + "/";
        var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);

     
        Debug.Log(data);*/
    }

 

    // ĳ���Ͱ� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ����� �մϴ�.
    public void FreshSlot()
    {
        int i = 0;
        for (; i < Chacters.Count && i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = Chacters[i];
        }
        for (; i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = null;
        }
    }

    void addChar() {
        //L_ID�� ����� ���� ���丮�� ���� ������ ĳ���Ϳ� �߰� (L_ID ���̸�ŭ)
        if (float.Parse(L_ID[0]) == InitChar[0].GetComponent<Stat>().fId) {
            Chacters.Add(InitChar[0].GetComponent<Stat>());
        }
    }



    /*
    void CheckCharactor() {
        //���ÿ� �ִ� ĳ���� Id�� �ʱ�ȭ�� ĳ���� Id�� üũ  ������  Chacters�迭�� add �ϱ� 
        a = Application.persistentDataPath + "/"; 
        var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
        Debug.Log(float.Parse(data["fId"]));//���� ĳ��
      

        
        //JOSN ���� �����ͼ�   ���� JSON�ϰ� �� ��  ������ �������� 
        if (float.Parse(data["fId"]) == InitChar[0].GetComponent<Stat>().fId) {
            Chacters.Add(InitChar[0].GetComponent<Stat>());
        }
    }*/

    List<string> RoadChar(string sPath) {
        List<string> list = new List<string>();
        List<Dictionary<string, string>> listTemp = GameManager.instance.DataReadAll(sPath);
        var a = GameManager.instance.stageFactory.characterFactory.listPool;
        foreach (Dictionary<string,string> dictTemp in listTemp)
		{
            if (dictTemp[CharPath.ISOWN] == "True")
			{
                list.Add(dictTemp[CharPath.ID]);
            }

        }
        
        return list;
    }

    void CheckChar() { 
    
    
    }


    /*
    public void AddItem(Stat stat)
    {
        if (Chactors.Count < s_Slots.Length)
        {
            Chactors.Add(stat);
            FreshSlot();
        }
        else
        {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }*/
}
