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
    //public List<GameObject> Chacters;



    //슬롯을 가지고있는 부모 오브젝트
    [SerializeField]
    private Transform tSlotParent;
    //슬롯 배열
    [SerializeField]
    public Slot[] s_Slots;
    
    public string _sFolderPath;

  


    //내가 가지고 있는 캐릭터
    public List<string> L_ID;
    


	void Start()
    {
        _sFolderPath= FolderPath.PARAMS_CHARACTER;
        //L_ID = RoadChar(_sFolderPath);
        //리스트풀 만들어서 init 리스트에 넣기 
     
        //addChar() ;
        FreshSlot();
        //GameManager.instance.objectFactory.ownCharFactory.listPool = Chacters;
    }

 

    // 캐릭터가 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능을 합니다.
    public void FreshSlot()
    {
        int i = 0;
        for (; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count && i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = GameManager.instance.objectFactory.ownCharFactory.listPool[i].GetComponent<Stat>();
        }
        for (; i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = null;
            s_Slots[i].transform.parent.gameObject.SetActive(false);
        }
           
    }
}
