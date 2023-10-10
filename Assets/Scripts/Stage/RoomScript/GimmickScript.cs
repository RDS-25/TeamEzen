using Params;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickScript : MonoBehaviour
{
    [SerializeField]
    private GimmickRoomParams.ROOM_TYPE room_type = GimmickRoomParams.ROOM_TYPE.NONE;
    [SerializeField]
    private Gimmick activeGimmick;

    public GameObject gStore;
    public GameObject gStoreUi;
    public GameObject gTrapUi;
    public GimmickRoomParams.ROOM_TYPE GIMMICK_TYPE
    {
        get
        {
            return room_type;
        }
    }
    // Start is called before the first frame update
    public void SetRoomType()
    {
        switch (room_type)
        {
            case GimmickRoomParams.ROOM_TYPE.MONSTER_ROOM:
                activeGimmick = new MonsterGimmick();
                break;
            case GimmickRoomParams.ROOM_TYPE.STORE_ROOM:
                activeGimmick = new StoreGimmick();
                break;
            case GimmickRoomParams.ROOM_TYPE.TRAP_ROOM:
                activeGimmick = new TrapGimmick();
                break;
        }

        activeGimmick.InitializeGimmick(this, gStore, gStoreUi, gTrapUi);
    }

    void Update()
    {
        if(activeGimmick!= null)
            activeGimmick.UpdateGimmick();
    }

    void OnTriggerEnter(Collider other)
    {
        activeGimmick.ActiveGimmick();
        Debug.Log("�ݶ��̴� ����");
    }

    private void OnTriggerExit(Collider other)
    {
        activeGimmick.DiableGimmick();
    }

    public int OBJECT_COUNT
    {
        get
        {
            int value = 0;
            switch (room_type)
            {
                case GimmickRoomParams.ROOM_TYPE.MONSTER_ROOM:
                    value = ((MonsterGimmick)activeGimmick).monsterCount;
                    break;
                case GimmickRoomParams.ROOM_TYPE.STORE_ROOM:
                    value = 1;
                    break;
                case GimmickRoomParams.ROOM_TYPE.TRAP_ROOM:
                    value = 1;
                    break;
            }
            
            return value;

        }
    }
}
