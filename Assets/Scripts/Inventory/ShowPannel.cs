using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowPannel : MonoBehaviour
{
    
    public Image Icon;
    public TMP_Text ItemName;
    public TMP_Text ItemDiscription;
    public TMP_Text PassiveSkillValue;
    public TMP_Text Damage;
    public TMP_Text Defense;
    public TMP_Text Speed;
    public TMP_Text UpDamage;
    public TMP_Text Crticalper;
    public TMP_Text CriticalDamage;    
    List<GameObject> SetItems = new List<GameObject>();//인벤에 들어간 아이템의 정보를 가진 게임오브젝트 리스트 
    void Start()
    {
        GetComponent<SlotManager>().SetButtonClickedEvent();
        HaveitemList();
        Debug.Log(SetItems.Count);
        Debug.Log("sdad");
    }
    private void OnEnable()
    {
       
        SlotManager.OnButtonClick += ShowItemData;
    }
    private void OnDisable()
    {
        SlotManager.OnButtonClick -= ShowItemData;
    }
    public void HaveitemList()
    {
        for (int i = 0; i < GameManager.instance.objectFactory.ItemSlotFactory.listPool.Count; i++)
        {

            if (GameManager.instance.objectFactory.ItemObjectFactory.listPool[i].activeSelf)
            {
                SetItems.Add(GameManager.instance.objectFactory.ItemObjectFactory.listPool[i]);
            }
        }
        Debug.Log("sda");
    }
    public void ShowItemData(int index)
    {
        
        for (int i = 0; i < SetItems.Count; i++)
        {
            if (SetItems[i].GetComponent<UiCellView>().TYPE == 0)
            {
                transform.GetComponentInChildren<Image>().sprite = GameManager.instance.LoadAndSetSprite(SetItems[i].GetComponent<UiCellView>().IMAGE_PATH);
            }
                

        }
    }
        void Update()
    {
        
    }
}
