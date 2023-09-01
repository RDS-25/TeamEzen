using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field5 : MonoBehaviour
{
    public GameObject gStore;
    public GameObject gStoreUi;
    private bool bState = false;

    void OnTriggerEnter(Collider other)
    {
        if (!bState)
        {
            bState = true;
            gStore.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gStoreUi.SetActive(false);
    }
}
