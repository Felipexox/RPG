using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    [SerializeField]
    private Image iconSlot;
    [SerializeField]
    private int id;
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
       // Debug.Log("Deactive");
        color = Color.white;
        color.a = 0;
        iconSlot.color = color;
    }
    public void setIdSlot(int id)
    {
        this.id = id;

    }
    public void removeItemFromSlot()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.removeItemFromBag(id);
    }
    public void holdItemFromSlot()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.holdItemFromBag(id);
    }
    
}
