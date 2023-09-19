using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gimmick
{
    public void InitializeGimmick(MonoBehaviour mb);
    public void ActiveGimmick();
    public void DiableGimmick();
}