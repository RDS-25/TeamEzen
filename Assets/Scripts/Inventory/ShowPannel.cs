using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ItemParameter;

public class ShowPannel : MonoBehaviour
{
    public GameObject ShowItemDataPanel;
    public Transform ItemData;

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
        //HaveitemList();
       
    }
    private void OnEnable()
    {
        SlotManager.OnButtonClick += ShowItemData;
    }
    private void OnDisable()
    {
        SlotManager.OnButtonClick -= ShowItemData;
    }
    //public void HaveitemList()
    //{
    //    for (int i = 0; i < GameManager.instance.objectFactory.ItemSlotFactory.listPool.Count; i++)
    //    {

    //        if (GameManager.instance.objectFactory.ItemObjectFactory.listPool[i].activeSelf)
    //        {
    //            SetItems.Add(GameManager.instance.objectFactory.ItemObjectFactory.listPool[i]);
    //        }
    //    }
    //    Debug.Log("sda");
    //}
    public void ShowItemData(int index)
    {
        SetItems = GameManager.instance.objectFactory.SetItemFactory.listPool;
        ShowItemDataPanel.SetActive(true);
        //index번째 슬랏을 불러온다
        //슬랏 내부에 존재하는아이템의 데이터를 뽑아온다
        //아이템 아이디로부터 아이템의 파라미터를 뽑는다

        //ItemName = ItemData.GetComponentsInChildren<TMP_Text>()[0];
        //ItemDiscription = ItemData.GetComponentsInChildren<TMP_Text>()[1];                                                                                                                                                                                                                                                                                                
        //Damage = ItemData.GetComponentsInChildren<TMP_Text>()[2];
        //Defense = ItemData.GetComponentsInChildren<TMP_Text>()[3];
        //Speed = ItemData.GetComponentsInChildren<TMP_Text>()[4];
        //CriticalPer = ItemData.GetComponentsInChildren<TMP_Text>()[5];
        //CriticalDamage = ItemData.GetComponentsInChildren<TMP_Text>()[6];
        //PassiveSkillValue = ItemData.GetComponentsInChildren<TMP_Text>()[7];
        //UpDamage = ItemData.GetComponentsInChildren<TMP_Text>()[8];

        ItemData.GetChild(0).GetComponent<Image>().sprite 
            = GameManager.instance.LoadAndSetSprite(SetItems[index].GetComponent<UiCellView>().IMAGE_PATH);
        ItemName.text = SetItems[index].GetComponent<UiCellView>().NAME.ToString();
        ItemDiscription.text = SetItems[index].GetComponent<UiCellView>().DISCRIPTION.ToString();


        if (SetItems[index].GetComponent<UiCellView>().TYPE == ItemType.PROFESSIONAL)//pro일때
        {
            Damage.text = SetItems[index].GetComponent<UiCellView>().DAMAGE.ToString();
            Defense.text = SetItems[index].GetComponent<UiCellView>().DEFENSE.ToString();
            Speed.text = SetItems[index].GetComponent<UiCellView>().SPEED.ToString();
            CriticalPer.text = SetItems[index].GetComponent<UiCellView>().CRITICALPER.ToString();
            CriticalDamage.text = SetItems[index].GetComponent<UiCellView>().CRITICALDAMAGE.ToString();
            PassiveSkillValue.text = SetItems[index].GetComponent<UiCellView>().PASSIVEVALUE.ToString();
            UpDamage.gameObject.SetActive(false);
        }
        else if (SetItems[index].GetComponent<UiCellView>().TYPE == ItemType.EQUIPMENT)
        {
            PassiveSkillValue.gameObject.SetActive(false);
            UpDamage.gameObject.SetActive(false);
            Damage.text = SetItems[index].GetComponent<UiCellView>().DAMAGE.ToString();
            Defense.text = SetItems[index].GetComponent<UiCellView>().DEFENSE.ToString();
            Speed.text = SetItems[index].GetComponent<UiCellView>().SPEED.ToString();
            CriticalPer.text = SetItems[index].GetComponent<UiCellView>().CRITICALPER.ToString();
            CriticalDamage.text = SetItems[index].GetComponent<UiCellView>().CRITICALDAMAGE.ToString();
        }
        else if (SetItems[index].GetComponent<UiCellView>().TYPE == ItemType.GEMSTONE)
        {
            Damage.gameObject.SetActive(false);
            Defense.gameObject.SetActive(false);
            Speed.gameObject.SetActive(false);
            CriticalPer.gameObject.SetActive(false);
            CriticalDamage.gameObject.SetActive(false);
            PassiveSkillValue.gameObject.SetActive(false);
            UpDamage.text = SetItems[index].GetComponent<UiCellView>().UPDAMAGE.ToString();
        }
        else
        {
            Damage.gameObject.SetActive(false);
            Defense.gameObject.SetActive(false);
            Speed.gameObject.SetActive(false);
            CriticalPer.gameObject.SetActive(false);
            CriticalDamage.gameObject.SetActive(false);
            PassiveSkillValue.gameObject.SetActive(false);
            UpDamage.gameObject.SetActive(false);
        }



    }
    public void ButtonBack()
    {
        ShowItemDataPanel.SetActive(false);

    }
    public void ButtonBackToLobby()
    {
        transform.parent.gameObject.SetActive(false);
    }
    void Update()
    {

    }
}
