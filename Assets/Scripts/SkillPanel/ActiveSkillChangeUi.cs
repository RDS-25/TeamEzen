using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActiveSkillChangeUi : MonoBehaviour
{
    public SkillUiManager skillUiManager;
    public SkillPanelUi skillPanelUi;
    public SlotManager slotManager;
    public Transform gSlots;
    private void OnEnable()
    {
        SlotManager.OnSkillChange += ChangeSkill;
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
        skillUiManager = GameObject.Find("SkillUiManager").GetComponent<SkillUiManager>();
        skillPanelUi = GameObject.Find("SkillPanelUi").GetComponent<SkillPanelUi>();
    }
    void ChangeSkill(int index)
    {
        Debug.Log(index);
        skillPanelUi.curCharStat.fActiveSkill = GameManager.instance.objectFactory.SelectingSkillObjectFactory.listPool[index].GetComponent<Skill>().fId;
        skillUiManager.ButtonToSkillPanelBack();
        skillPanelUi.ShowSkill();
    }
}
