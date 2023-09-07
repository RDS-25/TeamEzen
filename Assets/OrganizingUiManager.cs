using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizingUiManager : MonoBehaviour
{
    public GameObject gOranaizngPanel;

    public SlotManager slotManager;
    public Transform gSlots;
    private void OnEnable()
    {
        SlotManager.OnButtonClick += SelectChar;
    }
    private void OnDisable()
    {
        SlotManager.OnButtonClick -= SelectChar;
    }
    void Start()
    {
        gOranaizngPanel.SetActive(false);
        
        slotManager.SetSlot(GameManager.instance.objectFactory.OrganizingSlotFactory.listPool,
                            GameManager.instance.objectFactory.characterFactory.listPool,
                            gSlots,
                            SlotManager.OBJECT_TYPE.CHARACTER);
    }
    public void ButtonLoadStage()
    {
        LoadingSceneManager.LoadScene("StageScene");
    }
    public void ButtonBack()
    {
        gOranaizngPanel.SetActive(false);
    }
    public void SelectChar(int index)
    {
        Debug.Log("편성 추가하기");
    }
}
