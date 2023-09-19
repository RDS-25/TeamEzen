using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGimmick : Gimmick
{
    public GameObject gStore;
    public GameObject gStoreUi;
    private bool bState = false;

    public void InitializeGimmick(MonoBehaviour mb)
    {
        // GameObject 변수 받아오기
    }
    public void ActiveGimmick()
    {
        if (!bState)
        {
            bState = true;
            gStore.SetActive(true);
        }
    }

    public void DiableGimmick()
    {
        gStoreUi.SetActive(false);
    }
}
