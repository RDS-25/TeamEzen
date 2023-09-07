using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SlotManager : MonoBehaviour
{
    public enum OBJECT_TYPE
    {
        CHARACTER,
        ITEM
    }
    public Button[] SlotButtons;
    public Transform SlotsInViewport;
    public int nButtonIndex;

    public delegate void ButtonClickAction(int index);
    public static event ButtonClickAction OnButtonClick;

    void OnEnable()
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
        for (int i = 0; i < slotObjects.Count; i++)
        {
            slotObjects[i].transform.parent = Slots;
            if (objType == OBJECT_TYPE.CHARACTER)
            {
                if (allObjList[i].GetComponent<Stat>().bIsOwn)
                {
                    slotObjects[i].SetActive(true);
                    Slots.GetChild(i).GetComponent<Image>().sprite
                        = GameManager.instance.LoadAndSetSprite(allObjList[i].GetComponent<Stat>().sImagepath);
                }
            }
            else if(objType == OBJECT_TYPE.ITEM)
            {
                // 재욱씨가 넣기
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
