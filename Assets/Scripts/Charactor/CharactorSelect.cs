using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSelect : MonoBehaviour
{
    public List<Stat> Chactors;

    [SerializeField]
    private Transform tSlotParent;
    [SerializeField]
    private Slot[] s_Slots;

    //시작 버튼 없이  유니티 에디터 키기만하면 실행 되는 함수 
    private void OnValidate()
    {
        s_Slots = tSlotParent.GetComponentsInChildren<Slot>();
    }

    void Start()
    {
        FreshSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 캐릭터가 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능을 합니다.
    public void FreshSlot()
    {
        int i = 0;
        for (; i < Chactors.Count && i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = Chactors[i];
        }
        for (; i < s_Slots.Length; i++)
        {
            s_Slots[i].Stat = null;
        }
    }

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
    }
}
