using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewMain : MonoBehaviour
{
    public UiScrollViewDirector uiDirector;
    public GameObject invenpan;
    private void Start()
    {
        ItemDatamanager.instance.LoadEquipData();
        this.uiDirector.Init();
    }
    public void ButtonOn()
    {
        invenpan.SetActive(false);
    }
}
