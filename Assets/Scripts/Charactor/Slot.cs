using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    private Stat _Stat;
    public SpriteRenderer spriteRenderer; // Sprite�� ǥ���� SpriteRenderer

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
        // Resources ���� ���� �̹��� ������ �־�� �մϴ�.
        Sprite loadedSprite = Resources.Load<Sprite>(imagePath);

        if (loadedSprite != null)
        {
            // SpriteRenderer�� Sprite ����
          return loadedSprite;
        }
        else
        {
            Debug.LogError("Sprite�� ã�� �� �����ϴ�: " + imagePath);
            return null;
        }
    }

}
