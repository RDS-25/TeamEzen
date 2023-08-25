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

    //게임에서 전부 가지고 있는 캐릭터
    public List<GameObject> InitChar;

    //슬롯을 가지고있는 부모 오브젝트
    [SerializeField]
    private Transform tSlotParent;
    //슬롯 배열
    [SerializeField]
    private Slot[] s_Slots;
    
    public string _sFolderPath;


    //내가 가지고 있는 캐릭터
    public List<string> L_ID;
    


	void Start()
    {
        _sFolderPath= Application.persistentDataPath + "/ParamsFolder/CharParams/";
        L_ID = RoadChar(_sFolderPath);
        //리스트풀 만들어서 init 리스트에 넣기 
        InitChar = GameManager.instance.stageFactory.characterFactory.listPool;
        addChar() ;
        FreshSlot();
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
            s_Slots[i].transform.parent.gameObject.SetActive(false);
        }
           
    }

    void addChar() {
        //L_ID의 저장된 값과 팩토리의 값이 같으면 캐릭터에 추가 (L_ID 길이만큼)
        for(int i = 0; i < InitChar.Count; i++)
		{
            for(int j = 0; j < L_ID.Count; j++)
			{
                if (InitChar[i].GetComponent<Stat>().fId == float.Parse(L_ID[j]))
                    Chacters.Add(InitChar[i].GetComponent<Stat>());
			}
		}
 
    }
    //보유하고있는  캐릭터를 확인해서 리스트에 넣기 
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
            print("슬롯이 가득 차 있습니다.");
        }
    }*/
}
