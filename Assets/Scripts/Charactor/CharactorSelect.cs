using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelect : MonoBehaviour
{

    //���� ������ �ִ� ĳ���� 
    //json���� ���� ���� (id, sprite)
    public List<Stat> Chacters;

    //�ѹ� �ʱ�ȭ�Ѱ�
    public GameObject Char;
    //������ �������ִ� �θ� ������Ʈ
    [SerializeField]
    private Transform tSlotParent;
    //���� �迭
    [SerializeField]
    private Slot[] s_Slots;
    string a;
    //���� ��ư ����  ����Ƽ ������ Ű�⸸�ϸ� ���� �Ǵ� �Լ� 


	private void OnEnable()
	{
        CheckCharactor();

    }
	void Start()
    {
        FreshSlot();
      
      /*  string a = Application.persistentDataPath + "/";
        var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);

     
        Debug.Log(data);*/
    }

    // Update is called once per frame
    void Update()
    {
        
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

    
    void CheckCharactor() {
        //���ÿ� �ִ� ĳ���� Id�� �ʱ�ȭ�� ĳ���� id�� üũ  ������  Chacters�迭�� add �ϱ� 
        a = Application.persistentDataPath + "/"; 
        var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);
        Debug.Log(float.Parse(data["fId"]));
        Debug.Log (Char.GetComponentInChildren<Stat>().fId);

        
        if (float.Parse(data["fId"]) == Char.GetComponentInChildren<Stat>().fId) {
            Chacters.Add(Char.GetComponentInChildren<Stat>());
        }

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
