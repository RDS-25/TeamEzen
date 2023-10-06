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
            vBossRoom = RoomManager.vRoomPos[Random.Range(0, RoomManager.vRoomPos.Length)];
            gameObject.transform.position = vBossRoom;
        }
    }
}
