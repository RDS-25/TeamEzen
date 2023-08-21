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


    //�ѹ� �ʱ�ȭ�Ѱ�
    public Transform InitCharParent;

    public List<Stat> InitChar;

   
    //������ �������ִ� �θ� ������Ʈ
    [SerializeField]
    private Transform tSlotParent;
    //���� �迭
    [SerializeField]
    private Slot[] s_Slots;
    string a;
  


	private void OnEnable()
	{
        FreshInitChar();
        CheckCharactor();
      

    }
	void Start()
    {
       FreshSlot();
      
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

    //�ʱ�ȭ�� ĳ���͵� ������ �ֱ� 
    public void FreshInitChar() {
        for (int i = 0; i < InitCharParent.childCount; i++) {
            Debug.Log(InitCharParent.GetChild(i).name);
            InitChar.Add(InitCharParent.GetChild(i).GetComponent<Stat>());
        }
    }

    
    void CheckCharactor() {
        //���ÿ� �ִ� ĳ���� Id�� �ʱ�ȭ�� ĳ���� Id�� üũ  ������  Chacters�迭�� add �ϱ� 
        a = Application.persistentDataPath + "/"; 
        var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);
        Debug.Log(float.Parse(data["fId"]));//���� ĳ��
      

        /*
        //JOSN ���� �����ͼ�   ���� JSON�ϰ� �� ��  ������ �������� 
        if (float.Parse(data["fId"]) == InitChar[0].GetComponent<Stat>().fId) {
            Chacters.Add(InitChar[0].GetComponent<Stat>());
        }*/

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
