using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gimmick
{
    public void InitializeGimmick(MonoBehaviour mb, GameObject gStore, GameObject gStoreUi);
    public void ActiveGimmick();
    public void DiableGimmick();
}