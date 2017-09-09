using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    [SerializeField]
    private Image iconSlot;
  
    public void setIcon(Sprite image)
    {
         iconSlot.sprite = image;
    }

    public void activeItem()
    {
        iconSlot.color = Color.white;
    }
    public void deactive()
    {
        Color32 color = new Color32();
        color = Color.white;
        color.a = 0;
        iconSlot.color = color;
    }

}
