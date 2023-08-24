using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewMain : MonoBehaviour
{
    public UiScrollViewDirector uiDirector;
    private void Start()
    {
        ItemDatamanager.instance.LoadEquipData();
        this.uiDirector.Init();
    }
}
