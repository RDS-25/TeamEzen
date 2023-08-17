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

    //���� ��ư ����  ����Ƽ ������ Ű�⸸�ϸ� ���� �Ǵ� �Լ� 
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

    // ĳ���Ͱ� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ����� �մϴ�.
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
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }
}
