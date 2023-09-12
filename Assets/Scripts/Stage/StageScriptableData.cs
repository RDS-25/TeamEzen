using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

[CreateAssetMenu(fileName = "StageScriptableData", menuName = "Scriptable Object/StageScriptableData", order = int.MaxValue)]
public class StageScriptableData : ScriptableObject
{
    [SerializeField]
    private StageParams.STAGE_TYPE typeChapter;
    [SerializeField]
    //�÷��� ���� �������� Ŭ���� ����
    private bool bClear = false;
    [SerializeField]
    //�ִ� ����� �ִ� ��ͷ� ��
    private int nMaxRoomCount = 0;
    [SerializeField]
    //������� ��ͷ� ��
    private int nRoomcount = 0;
    [SerializeField]
    //Ŭ����� ��ͷ� ��
    private int nClearRoomCount = 0;
    [SerializeField]
    //���� ��
    private int nBossCount = 0;
    //���� ����
    [SerializeField]
    private int nStoreCount = 0;
    [SerializeField]
    //�������� �̸�
    public string strStageName = "";
    public bool ChapterTypeCompare(StageParams.STAGE_TYPE type)
    {
        return typeChapter == type;
    }
    public void DataInit(StageParams sparam)
    {

        sparam.bClear = bClear;
        sparam.nMaxRoomCount = nMaxRoomCount;
        sparam.nRoomcount = nRoomcount;
        sparam.nClearRoomCount = nClearRoomCount;
        sparam.nBossCount = nBossCount;
        sparam.strStageName = strStageName;
        sparam.nStoreCount = nStoreCount;
        sparam.typeChapter = typeChapter;
    }
}
