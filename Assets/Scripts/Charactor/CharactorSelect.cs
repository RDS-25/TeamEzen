using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    로컬의 데이터와 초기화된 데이터 비교하는 과정
    1.게임 캐릭터를 CharactorGroups 오브젝트에서 전부 생성후 비활성화
    2.CharactorGroups 오브젝트들은 InitChar란 리스트에서 넣기
    3.로컬에 저장된 가지고 있는 캐릭터 JSON 와 InitChar에 넣어둔 오브젝트를 비교
    4.true면 활성화해서 보여주기 그대로 두기
    
 */
public class CharactorSelect : MonoBehaviour
{

    //내가 가지고 있는 캐릭터 
    //json들의 정보 대입 (id, sprite)
    public List<Stat> Chacters;


    //한번 초기화한값
    public Transform InitCharParent;

    public List<Stat> InitChar;

   
    //슬롯을 가지고있는 부모 오브젝트
    [SerializeField]
    private Transform tSlotParent;
    //슬롯 배열
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

    //초기화된 캐릭터들 가져다 넣기 
    public void FreshInitChar() {
        for (int i = 0; i < InitCharParent.childCount; i++) {
            Debug.Log(InitCharParent.GetChild(i).name);
            InitChar.Add(InitCharParent.GetChild(i).GetComponent<Stat>());
        }
    }

    
    void CheckCharactor() {
        //로컬에 있는 캐릭터 Id와 초기화된 캐릭터 Id를 체크  있으면  Chacters배열에 add 하기 
        a = Application.persistentDataPath + "/"; 
        var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);
        Debug.Log(float.Parse(data["fId"]));//로컬 캐릭
      

        /*
        //JOSN 전부 가져와서   로컬 JSON하고 비교 후  있으면 가져오기 
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
            print("슬롯이 가득 차 있습니다.");
        }
    }*/
}
