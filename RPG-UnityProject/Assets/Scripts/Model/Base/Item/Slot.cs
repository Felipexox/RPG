using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    [SerializeField]
    private Image iconSlot;
    [SerializeField]
    private Item.typeItem type;
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
        id = -1;
    }
    public void setIdSlot(int id)
    {
        this.id = id;

    }
    public void removeItemFromSlot()
    {
        if (id >= 0)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.removeItemFromBag(id);
        }
    }
    public void setType(Item.typeItem type)
    {
        this.type = type;
    }
    public void interactItemFromSlot()
    {
        if (id >= 0)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (type == Item.typeItem.WEAPON)
            {
                player.holdItemFromBag(id);
            }
            else if (type == Item.typeItem.CONSUMABLE)
            {

            }
            else if (type == Item.typeItem.EQUIPAMENT)
            {
                player.equipItemFromBag(id);
            }
        }
    }
    
}
