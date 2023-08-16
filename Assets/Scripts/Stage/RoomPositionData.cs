using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomPositionData", menuName = "Scriptable Object/RoomPositionData", order = int.MaxValue)]
public class RoomPositionData : ScriptableObject
{
    //Room의 x좌표
    [SerializeField]
    private float fPos_x;
    //Room의 y좌표
    [SerializeField]
    private float fPos_y;
    //Room의 z좌표
    [SerializeField]
    private float fPos_z;
    //기믹 포지션의 x좌표들
    [SerializeField]
    private float[] fGimmick_pos_x;
    //기믹 포지션의 y좌표들
    [SerializeField]
    private float[] fGimmick_pos_y;
    //기믹 포지션의 z좌표들
    [SerializeField]
    private float[] fGimmick_pos_z;

    //스크립터블 오브젝트가 가진 Room의 좌표 건내주는 함수
    public void SetRoomPosData(GameObject trRoomPosObject)
    {
        trRoomPosObject.transform.position = new Vector3(fPos_x, fPos_y, fPos_z);
    }
    //스크립터블 오브젝트가 가진 기밎의 좌표 건내주는 함수
    public bool SetGimmickPosData(GameObject objGimmickPos, int idx)
    {
        if (idx >= fGimmick_pos_x.Length
            || idx >= fGimmick_pos_y.Length
            || idx >= fGimmick_pos_z.Length)
            return false;

        objGimmickPos.transform.position = new Vector3(fPos_x + fGimmick_pos_x[idx], fPos_y + fGimmick_pos_y[idx], fPos_z + fGimmick_pos_z[idx]);

        return true;
    }
}
