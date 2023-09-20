using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActiveSkillChangeUi : MonoBehaviour
{
    public SkillUiManager skillUiManager;
    public SkillPanelUi skillPanelUi;
    public SlotManager slotManager;
    public Transform gSlots;

    private void OnEnable()
    {
        SlotManager.OnSkillChange += ChangeSkill;
        List<GameObject> SelectingSKill = GameManager.instance.objectFactory.SelectingSkillObjectFactory.listPool;
        List<GameObject> SelectingSKillSlot = GameManager.instance.objectFactory.SelectingSkillSlotFactory.listPool;
        for (int i = 0; i < SelectingSKill.Count; i++)
        {
            if(skillPanelUi.curCharStat.fId == SelectingSKill[i].GetComponent<Skill>().fCharToUse
                || SelectingSKill[i].GetComponent<Skill>().fCharToUse == -1)
            {
                SelectingSKillSlot[i].SetActive(true);
            }
        }
    }
    private void OnDisable()
    {
        SlotManager.OnSkillChange -= ChangeSkill;
    }
    private void Awake()
    {
        slotManager.SetSlot(GameManager.instance.objectFactory.SelectingSkillSlotFactory.listPool,
                    GameManager.instance.objectFactory.SelectingSkillObjectFactory.listPool,
                    gSlots,
                    SlotManager.OBJECT_TYPE.SKILL);
        slotManager.SetSkillChangeEvent();
    }
    void Start()
    {
    }
    void ChangeSkill(int index)
    {
        Debug.Log(index);
        skillPanelUi.curCharStat.fActiveSkill = GameManager.instance.objectFactory.SelectingSkillObjectFactory.listPool[index].GetComponent<Skill>().fId;
        skillUiManager.ButtonToSkillPanelBack();
        skillPanelUi.ShowSkill();
    }
}
