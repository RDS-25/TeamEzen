using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGimmick : Gimmick
{
    private GameObject gStore;
    private GameObject gStoreUi;
    private bool bState = false;
    MonoBehaviour mb;

    public void InitializeGimmick(MonoBehaviour mb, GameObject Stroe, GameObject StoreUi, GameObject TrapUi)
    {
        this.mb = mb;
        // GameObject 변수 받아오기
        gStore = Stroe;
        gStoreUi = StoreUi;
    }
    public void UpdateGimmick()
    {

    }

    public void ActiveGimmick()
    {
        if (!bState)
        {
            bState = true;
            gStore.SetActive(true);
            RoomManager.nClearCount++;
            RoomManager.vRoomPos = mb.transform.position;
        }
    }

    public void DiableGimmick()
    {
        gStoreUi.SetActive(false);
    }
}
