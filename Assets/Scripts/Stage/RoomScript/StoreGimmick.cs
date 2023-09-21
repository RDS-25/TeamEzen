using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGimmick : Gimmick
{
    private GameObject gStore;
    private GameObject gStoreUi;
    private bool bState = false;

    public void InitializeGimmick(MonoBehaviour mb, GameObject a, GameObject b)
    {
        // GameObject 변수 받아오기
        gStore = a;
        gStoreUi = b;
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
