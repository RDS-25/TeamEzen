using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gimmick
{
    public void InitializeGimmick(MonoBehaviour mb, GameObject Store, GameObject StoreUi, GameObject TrapUi);
    public void UpdateGimmick();
    public void ActiveGimmick();
    public void DiableGimmick();
}