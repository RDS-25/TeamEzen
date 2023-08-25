using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

namespace Params
{
    //    - 스테이지
    //    - 맵크기
    //    - 스테이지 타입
    //    - 룸 개수
    //    - 기믹 최대 개수
    //    - 스테이지 보상(n지 선다형)
    //    - 트리거 타입(보스, 기믹형, 몬스터, 상점)
    //    - 상점
    //    - 오브젝트 타입(아이템, 버프)
    //    - 기믹
    //    - 클리어 여부
    //    - 트리거 타입
    //    - 최대 오브젝트 갯수
    //    - 기믹 타입(상세 기입)
    public class StageParams
    {
        //스테이지 챕터 상수
        public enum STAGE_TYPE
        {
            TUTORIAL,
            CHAPTER1,
            CHAPTER2,
            CHAPTER3,
            CHAPTER4,
            CHAPTER5,
            NONE
        }

        public STAGE_TYPE typeChapter = STAGE_TYPE.NONE;
        //플레이 중인 스테이지 클리어 여부
        public bool bClear = false;
        //현재 챕터의 클리어 여부
        public bool bChapterClear = false;
        //상점 유무
        public int nStoreCount = 0;
        //최대 만들수 있는 기믹룸 수
        public int nMaxRoomCount = 0;
        //만들어진 기믹룸 수
        public int nRoomcount = 0;
        //클리어된 기믹룸 수
        public int nClearRoomCount = 0;
        //보스 수
        public int nBossCount = 0;
        //클리어된 스테이지의 별 수
        public int nStarPoint = 0;
        //스테이지 이름
        public string strStageName = "";
        //플레이어 오브젝트
        public GameObject gPlayer = null;
    }

    public class GimmickRoomParams
    {
        //기믹룸 타입
        public enum ROOM_TYPE
        {
            MONSTER_ROOM,//60
            PUZZLE_ROOM,//20
            TRAP_ROOM,//20
            STORE_ROOM,//50%로 있나 없나
            BOSS_ROOM,
            NONE
        }
        
        public ROOM_TYPE roomType = ROOM_TYPE.NONE;
        //현재 진행중인 기믹룸의 클리어 여부
        public bool bClearRoom = false;
        //기믹룸 포지션 높이
        public float fMapHight = 0.0f;
        //기믹룸 포지션 너비
        public float fMapWidth = 0.0f;
        //기믹룸 포지셩 아이디
        public int nId = 0;
        //클리어해야하는 총 기믹 수
        public int nMaxEventCount = 0;
        //클리어된 기믹수
        public int nClearEventCount = 0;
        //기믹의 바닥좌표 배열
        public Transform[] trGroundPositions = null;
        //기믹의 벽 좌표 배열
        public Transform[] trWellPositions = null;
    }

    public interface DefaultRoom
    {
        //초기화 함수
        bool Initialize(GameObject positionObjects, Object roomType, GameObject player);
        //오브젝트 팩토리 형성 함수
        bool CreateObjectFactory(string objectName);
        //기믹 오브젝트를 특정 포지션에 배치
        void SetObjectPosition();
        //기믹룸 활성화
        void EnableRoom();
        //기믹룸 비활성화
        void DisableRoom();
        //기믹 룸 클리어시 보상을 주기 위한 함수
        void ClearRoom();
    }
}
