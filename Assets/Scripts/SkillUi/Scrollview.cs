using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollview : MonoBehaviour
{
    public Transform content;
    public GameObject cellviewPrefab;
    private const int THRESHHOLD= 24;

    public void Init()
    {//가지고 있는 아이템 갯수만큼 생성
        int myItemCount = 10;
        
        for(int i=0;i<10 ;i++)
        {
            var go = Instantiate(this.cellviewPrefab, this.content);
            var cellview = go.GetComponent<UiCellView>();
            //아이콘,수량등 추가
            //cellview.Init();
        }
        this.GetComponent<ScrollRect>().vertical = myItemCount > THRESHHOLD;
    }
}
