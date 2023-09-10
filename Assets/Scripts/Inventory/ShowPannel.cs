using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ItemParameter;

public class ShowPannel : MonoBehaviour
{
    
    public Image Icon;
    public TMP_Text ItemName;
    public TMP_Text ItemDiscription;    
    public TMP_Text Damage;
    public TMP_Text Defense;
    public TMP_Text Speed;    
    public TMP_Text CriticalPer;
    public TMP_Text CriticalDamage;
    public TMP_Text PassiveSkillValue;
    public TMP_Text UpDamage;
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
            ItemName = transform.GetComponentsInChildren<TMP_Text>()[0];
            ItemDiscription = transform.GetComponentsInChildren<TMP_Text>()[1];
            Damage = transform.GetComponentsInChildren<TMP_Text>()[2];
            Defense = transform.GetComponentsInChildren<TMP_Text>()[3];
            Speed = transform.GetComponentsInChildren<TMP_Text>()[4];
            CriticalPer = transform.GetComponentsInChildren<TMP_Text>()[5];
            CriticalDamage = transform.GetComponentsInChildren<TMP_Text>()[6];
            PassiveSkillValue = transform.GetComponentsInChildren<TMP_Text>()[7];
            UpDamage = transform.GetComponentsInChildren<TMP_Text>()[8];

            transform.GetComponentInChildren<Image>().sprite = GameManager.instance.LoadAndSetSprite(SetItems[i].GetComponent<UiCellView>().IMAGE_PATH);
            ItemName.text = SetItems[i].GetComponent<UiCellView>().NAME.ToString();
            ItemDiscription.text= SetItems[i].GetComponent<UiCellView>().DISCRIPTION.ToString();


            if (SetItems[i].GetComponent<UiCellView>().TYPE == ItemType.PROFESSIONAL)//pro일때
            {
                Damage.text = SetItems[i].GetComponent<UiCellView>().DAMAGE.ToString();
                Defense.text = SetItems[i].GetComponent<UiCellView>().DEFENSE.ToString();
                Speed.text = SetItems[i].GetComponent<UiCellView>().SPEED.ToString();
                CriticalPer.text = SetItems[i].GetComponent<UiCellView>().CRITICALPER.ToString();
                CriticalDamage.text = SetItems[i].GetComponent<UiCellView>().CRITICALDAMAGE.ToString();
                PassiveSkillValue.text = SetItems[i].GetComponent<UiCellView>().PASSIVEVALUE.ToString();
                UpDamage.enabled = false;
            }
            else if (SetItems[i].GetComponent<UiCellView>().TYPE == ItemType.EQUIPMENT)
            {
                PassiveSkillValue.enabled = false;
                UpDamage.enabled = false;
                Damage.text = SetItems[i].GetComponent<UiCellView>().DAMAGE.ToString();
                Defense.text = SetItems[i].GetComponent<UiCellView>().DEFENSE.ToString();
                Speed.text = SetItems[i].GetComponent<UiCellView>().SPEED.ToString();
                CriticalPer.text = SetItems[i].GetComponent<UiCellView>().CRITICALPER.ToString();
                CriticalDamage.text = SetItems[i].GetComponent<UiCellView>().CRITICALDAMAGE.ToString();
            }
            else if (SetItems[i].GetComponent<UiCellView>().TYPE == ItemType.GEMSTONE)
            {
                Damage.enabled = false;
                Defense.enabled = false;
                Speed.enabled = false;
                CriticalPer.enabled = false;
                CriticalDamage.enabled = false;
                PassiveSkillValue.enabled = false;
                UpDamage.text = SetItems[i].GetComponent<UiCellView>().UPDAMAGE.ToString();
            }
            else
            {
                Damage.enabled = false;
                Defense.enabled = false;
                Speed.enabled = false;
                CriticalPer.enabled = false;
                CriticalDamage.enabled = false;
                PassiveSkillValue.enabled = false;
                UpDamage.enabled = false;
            }
            

        }
    }
        void Update()
    {
        
    }
}
