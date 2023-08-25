using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    private Stat _Stat;



    //이미지 가져오기 
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

    //바이트 배열로 가져오기 
    private Sprite LoadAndSetSprite(string imagePath)
    {
        string path = Path.Combine(imagePath);

        Debug.Log("경로는"+path);
        if (File.Exists(path))
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(imageBytes))
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError("Failed to load image: " + imagePath);
                return null;
            }
        }
        else
        {
            Debug.LogError("Image file not found: " + path);
            return null;
        }
    }

}
