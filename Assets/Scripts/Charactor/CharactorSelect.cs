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

    //���ӿ��� ���� ������ �ִ� ĳ����
    public List<GameObject> InitChar;

    //������ �������ִ� �θ� ������Ʈ
    [SerializeField]
    private Transform tSlotParent;
    //���� �迭
    [SerializeField]
    private Slot[] s_Slots;
    
    public string _sFolderPath;


    //���� ������ �ִ� ĳ����
    public List<string> L_ID;
    


	void Start()
    {
        _sFolderPath= Application.persistentDataPath + "/ParamsFolder/CharParams/";
        L_ID = RoadChar(_sFolderPath);
        //����ƮǮ ���� init ����Ʈ�� �ֱ� 
        InitChar = GameManager.instance.stageFactory.characterFactory.listPool;
        addChar() ;
        FreshSlot();
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
            s_Slots[i].transform.parent.gameObject.SetActive(false);
        }
           
    }

    void addChar() {
        //L_ID�� ����� ���� ���丮�� ���� ������ ĳ���Ϳ� �߰� (L_ID ���̸�ŭ)
        for(int i = 0; i < InitChar.Count; i++)
		{
            for(int j = 0; j < L_ID.Count; j++)
			{
                if (InitChar[i].GetComponent<Stat>().fId == float.Parse(L_ID[j]))
                    Chacters.Add(InitChar[i].GetComponent<Stat>());
			}
		}
 
    }
    //�����ϰ��ִ�  ĳ���͸� Ȯ���ؼ� ����Ʈ�� �ֱ� 
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
