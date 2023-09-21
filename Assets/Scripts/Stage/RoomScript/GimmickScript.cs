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
    public GimmickRoomParams.ROOM_TYPE GIMMICK_TYPE
    {
        get
        {
            return room_type;
        }
    }
    // Start is called before the first frame update
    void Start()
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
        
        activeGimmick.InitializeGimmick(this, gStore, gStoreUi);
    }

    void OnTriggerEnter(Collider other)
    {
        activeGimmick.ActiveGimmick();
    }

    private void OnTriggerExit(Collider other)
    {
        activeGimmick.DiableGimmick();
    }
}
