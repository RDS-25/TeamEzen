using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomPositionData", menuName = "Scriptable Object/RoomPositionData", order = int.MaxValue)]
public class RoomPositionData : ScriptableObject
{
    //Room�� x��ǥ
    [SerializeField]
    private float fPos_x;
    //Room�� y��ǥ
    [SerializeField]
    private float fPos_y;
    //Room�� z��ǥ
    [SerializeField]
    private float fPos_z;
    //��� �������� x��ǥ��
    [SerializeField]
    private float[] fGimmick_pos_x;
    //��� �������� y��ǥ��
    [SerializeField]
    private float[] fGimmick_pos_y;
    //��� �������� z��ǥ��
    [SerializeField]
    private float[] fGimmick_pos_z;

    //��ũ���ͺ� ������Ʈ�� ���� Room�� ��ǥ �ǳ��ִ� �Լ�
    public void SetRoomPosData(GameObject trRoomPosObject)
    {
        trRoomPosObject.transform.position = new Vector3(fPos_x, fPos_y, fPos_z);
    }
    //��ũ���ͺ� ������Ʈ�� ���� ��G�� ��ǥ �ǳ��ִ� �Լ�
    public bool SetGimmickPosData(GameObject RoomPosObject, GameObject objGimmickPos, int idx)
    {
        if (idx >= fGimmick_pos_x.Length
            || idx >= fGimmick_pos_y.Length
            || idx >= fGimmick_pos_z.Length)
            return false;

        objGimmickPos.transform.position = RoomPosObject.transform.TransformPoint(fGimmick_pos_x[idx]*10, fGimmick_pos_y[idx]*10, fGimmick_pos_z[idx]*10);

        return true;
    }
}
