using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

namespace Params
{
    //    - ��������
    //    - ��ũ��
    //    - �������� Ÿ��
    //    - �� ����
    //    - ��� �ִ� ����
    //    - �������� ����(n�� ������)
    //    - Ʈ���� Ÿ��(����, �����, ����, ����)
    //    - ����
    //    - ������Ʈ Ÿ��(������, ����)
    //    - ���
    //    - Ŭ���� ����
    //    - Ʈ���� Ÿ��
    //    - �ִ� ������Ʈ ����
    //    - ��� Ÿ��(�� ����)
    public class StageParams
    {
        //�������� é�� ���
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
        //�÷��� ���� �������� Ŭ���� ����
        public bool bClear = false;
        //���� é���� Ŭ���� ����
        public bool bChapterClear = false;
        //���� ����
        public int nStoreCount = 0;
        //�ִ� ����� �ִ� ��ͷ� ��
        public int nMaxRoomCount = 0;
        //������� ��ͷ� ��
        public int nRoomcount = 0;
        //Ŭ����� ��ͷ� ��
        public int nClearRoomCount = 0;
        //���� ��
        public int nBossCount = 0;
        //Ŭ����� ���������� �� ��
        public int nStarPoint = 0;
        //�������� �̸�
        public string strStageName = "";
        //�÷��̾� ������Ʈ
        public GameObject gPlayer = null;
    }

    public class GimmickRoomParams
    {
        //��ͷ� Ÿ��
        public enum ROOM_TYPE
        {
            MONSTER_ROOM,//60
            PUZZLE_ROOM,//20
            TRAP_ROOM,//20
            STORE_ROOM,//50%�� �ֳ� ����
            BOSS_ROOM,
            NONE
        }
        
        public ROOM_TYPE roomType = ROOM_TYPE.NONE;
        //���� �������� ��ͷ��� Ŭ���� ����
        public bool bClearRoom = false;
        //��ͷ� ������ ����
        public float fMapHight = 0.0f;
        //��ͷ� ������ �ʺ�
        public float fMapWidth = 0.0f;
        //��ͷ� ������ ���̵�
        public int nId = 0;
        //Ŭ�����ؾ��ϴ� �� ��� ��
        public int nMaxEventCount = 0;
        //Ŭ����� ��ͼ�
        public int nClearEventCount = 0;
        //����� �ٴ���ǥ �迭
        public Transform[] trGroundPositions = null;
        //����� �� ��ǥ �迭
        public Transform[] trWellPositions = null;
    }

    public interface DefaultRoom
    {
        //�ʱ�ȭ �Լ�
        bool Initialize(GameObject positionObjects, Object roomType, GameObject player);
        //������Ʈ ���丮 ���� �Լ�
        bool CreateObjectFactory(string objectName);
        //��� ������Ʈ�� Ư�� �����ǿ� ��ġ
        void SetObjectPosition();
        //��ͷ� Ȱ��ȭ
        void EnableRoom();
        //��ͷ� ��Ȱ��ȭ
        void DisableRoom();
        //��� �� Ŭ����� ������ �ֱ� ���� �Լ�
        void ClearRoom();
    }
}
