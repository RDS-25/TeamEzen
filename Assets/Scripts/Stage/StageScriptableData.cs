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
    //플레이 중인 스테이지 클리어 여부
    private bool bClear = false;
    [SerializeField]
    //최대 만들수 있는 기믹룸 수
    private int nMaxRoomCount = 0;
    [SerializeField]
    //만들어진 기믹룸 수
    private int nRoomcount = 0;
    [SerializeField]
    //클리어된 기믹룸 수
    private int nClearRoomCount = 0;
    [SerializeField]
    //보스 수
    private int nBossCount = 0;
    //상점 유무
    [SerializeField]
    private int nStoreCount = 0;
    [SerializeField]
    //스테이지 이름
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
