using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    private Stat _Stat;
    public SpriteRenderer spriteRenderer; // Sprite를 표시할 SpriteRenderer

    public Stat Stat
    {
        get { return _Stat; }
        set
        {
            _Stat = value;
            if (_Stat != null)
            {
                image.sprite =LoadAndSetSprite(_Stat.sImagepath);
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
    private Sprite LoadAndSetSprite(string imagePath)
    {
        // Resources 폴더 내에 이미지 파일이 있어야 합니다.
        Sprite loadedSprite = Resources.Load<Sprite>(imagePath);

        if (loadedSprite != null)
        {
            // SpriteRenderer에 Sprite 설정
          return loadedSprite;
        }
        else
        {
            Debug.LogError("Sprite를 찾을 수 없습니다: " + imagePath);
            return null;
        }
    }

}
