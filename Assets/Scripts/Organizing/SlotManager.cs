using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class SlotManager : MonoBehaviour
{
    public enum OBJECT_TYPE
    {
        CHARACTER,
        ITEM
    }
    public Button[] SlotButtons;
    public Transform SlotsInViewport;
    public TMP_Text textPrefab;
    public int nButtonIndex;

    public delegate void ButtonClickAction(int index);
    public static event ButtonClickAction OnButtonClick;

    void OnEnable()
    {
        SetButtonClickedEvent();
    }

    public void SetButtonClickedEvent()
    {
        SlotButtons = SlotsInViewport.GetComponentsInChildren<Button>();
        for (int i = 0; i < SlotButtons.Length; i++)
        {
            int buttonIndex = i;
            SlotButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
    }

    public void SetSlot(List<GameObject> slotObjects, List<GameObject> allObjList, Transform Slots, OBJECT_TYPE objType)
    {
        Dictionary<string, string> dictTemp = new();
        if (objType == OBJECT_TYPE.CHARACTER)
        {
            for(int i = 0; i  <slotObjects.Count; i++)
            {
                slotObjects[i].transform.parent = Slots;
                if (allObjList[i].GetComponent<Stat>().bIsOwn)
                {
                    slotObjects[i].SetActive(true);
                    Slots.GetChild(i).GetComponent<Image>().sprite
                        = GameManager.instance.LoadAndSetSprite
                        (FolderPath.SPRITE_CHAR_ICON + allObjList[i].GetComponent<Stat>().sImagepath);
                }
            }
        }
        else if(objType == OBJECT_TYPE.ITEM)
        {
            dictTemp = GameManager.instance.DataRead(FolderPath.PARAMS_ITEM_COUNT + FileName.STR_JSON_INVEN_ITEMS);
            int i = 0;
            foreach(string key in dictTemp.Keys)
            {
                slotObjects[i].transform.parent = Slots;
                if (dictTemp[key] != "0")
                {
                    slotObjects[i].SetActive(true);
                    Slots.GetChild(i).GetComponent<Image>().sprite
                         = GameManager.instance.LoadAndSetSprite
                         (FolderPath.SPRITE_ITEM_ICON + allObjList[i].GetComponent<UiCellView>().IMAGE_PATH);
                }
                i++;
            }
        }
    }
    void OnClickButton(int index)
    {
        nButtonIndex = index;
        Debug.Log(nButtonIndex);
        OnButtonClick?.Invoke(nButtonIndex);

    }
}
