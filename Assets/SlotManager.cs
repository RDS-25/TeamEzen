using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SlotManager : MonoBehaviour
{
    public enum OBJECT_TYPE
    {
        CHARACTOR,
        ITEM
    }
    public Transform SlotsInViewport;
    public Button[] SlotButtons;
    int nButtonNum;

    // Start is called before the first frame update
    void Start()
    {
        //Init();
        InitTest(GameManager.instance.objectFactory.CharSlotFactory.listPool,
                GameManager.instance.objectFactory.characterFactory.listPool,
                OBJECT_TYPE.CHARACTOR);
    }
    public void InitTest(List<GameObject> slotObjects, List<GameObject> allCharList, OBJECT_TYPE objType)
    {
        for (int i = 0; i < slotObjects.Count; i++)
        {
            slotObjects[i].transform.parent = SlotsInViewport;
            if (objType == OBJECT_TYPE.CHARACTOR)
            {
                if (allCharList[i].GetComponent<Stat>().bIsOwn)
                {
                    slotObjects[i].SetActive(true);
                    SlotsInViewport.GetChild(i).GetComponent<Image>().sprite
                        = GameManager.instance.LoadAndSetSprite(allCharList[i].GetComponent<Stat>().sImagepath);
                }
            }
            else if(objType == OBJECT_TYPE.ITEM)
            {
                // 재욱씨가 넣기
            }

        }

    }

}
