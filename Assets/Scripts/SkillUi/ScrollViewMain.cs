using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewMain : MonoBehaviour
{
    public UiScrollViewDirector uiDirector;
    private void Start()
    {
        this.uiDirector.Init();
    }
}
