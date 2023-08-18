using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelect : MonoBehaviour
{

    //내가 가지고 있는 캐릭터 
    //json들의 정보 대입 (id, sprite)
    public List<Stat> Chacters;

    //한번 초기화한값
    public GameObject Char;
    //슬롯을 가지고있는 부모 오브젝트
    [SerializeField]
    private Transform tSlotParent;
    //슬롯 배열
    [SerializeField]
    private Slot[] s_Slots;
    string a;
    //시작 버튼 없이  유니티 에디터 키기만하면 실행 되는 함수 


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

    // 캐릭터가 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능을 합니다.
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
        //로컬에 있는 캐릭터 Id와 초기화된 캐릭터 id를 체크  있으면  Chacters배열에 add 하기 
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
            print("슬롯이 가득 차 있습니다.");
        }
    }*/
}
