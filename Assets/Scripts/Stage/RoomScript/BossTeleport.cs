using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    Vector3 vBossRoom;
    private bool bStart = false;

    private void OnTriggerEnter(Collider other)
    {
        if (bStart)
        {
            bStart = true;
            gameObject.transform.position = vBossRoom;

        }
    }
}
