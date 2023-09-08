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
    //public List<GameObject> Chacters;



    //������ �������ִ� �θ� ������Ʈ
    [SerializeField]
    private Transform tSlotParent;
    //���� �迭
    [SerializeField]
    public Slot[] s_Slots;
    
    public string _sFolderPath;

  


    //���� ������ �ִ� ĳ����
    public List<string> L_ID;
    


	void Start()
    {
        _sFolderPath= FolderPath.PARAMS_CHARACTER;
        //L_ID = RoadChar(_sFolderPath);
        //����ƮǮ ���� init ����Ʈ�� �ֱ� 
     
        //addChar() ;
        FreshSlot();
        //GameManager.instance.objectFactory.ownCharFactory.listPool = Chacters;
    }

 

    // ĳ���Ͱ� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ����� �մϴ�.
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
