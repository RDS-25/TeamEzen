using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class QuestManager
{
    public enum QuestType
    {
        NONE,
        MONSTER,
        GIMMICK
    }

    private QuestType _questType = QuestType.NONE;
    private bool _questClear = false;
    private int _contentMaxCount = 0;
    private int _contentCount = 0;
    private GameObject _questPanel;

    public bool QUEST_CLEAR
    {
        get { return _questClear; }
    }



    public QuestManager(GameObject questPanel)
    {
        _questPanel = questPanel;
    }


    public void InitQuest(QuestType questType, int conditionMaxCount, bool isStartCointMaxCount = false)
    {
        _questType = questType;
        _contentMaxCount = conditionMaxCount;
        if (isStartCointMaxCount)
            _contentCount = conditionMaxCount;
        else
            _contentCount = 0;
        SetQuestText(questType, conditionMaxCount, _contentCount);
        _questPanel.SetActive(true);
    }

    public void SetQuestText(QuestType questType, int conditionMaxCount, int conditionCount = 0)
    {
        string questName = "";
        string questContent = "";


        switch (questType)
        {
            case QuestType.MONSTER:
                questName = "Kill " + conditionMaxCount.ToString() + " monsters";
                questContent = "Remaining Monster Count : " + conditionCount.ToString() + " / " + conditionMaxCount.ToString();
                break;
            case QuestType.GIMMICK:
                //작성되지 않음
                break;
        }
        _questPanel.GetComponentsInChildren<TMPro.TMP_Text>()[0].text = questName;
        _questPanel.GetComponentsInChildren<TMPro.TMP_Text>()[1].text = questContent;
    }

    public void DeInitQuest()
    {
        _questClear = false;
        _contentMaxCount = 0;
        _contentCount = 0;
        _questType = QuestType.NONE;
        _questPanel.SetActive(false);
    }

    public void UpdateQuestProgress(bool questClear)
    {
        if (questClear) _questClear = true;
    }
    public void UpdateQuestProgress(int updateValue)
    {
        _contentCount += updateValue;

        if (_contentCount >= _contentMaxCount)
        {
            if (!_questClear) _questClear = true;
            _contentCount = _contentMaxCount;
        }

        SetQuestText(_questType, _contentMaxCount, _contentCount);

    }
}
