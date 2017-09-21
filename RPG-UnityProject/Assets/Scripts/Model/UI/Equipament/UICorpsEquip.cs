using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICorpsEquip : MonoBehaviour {

    protected Image uiImage;
    protected Item item;
    protected Slot slot;
    protected virtual void Start()
    {
        uiImage = GetComponent<Image>();
        slot = GetComponent<Slot>();
    }

    public virtual void setImage(Sprite sprite)
    {
        uiImage.sprite = sprite;
    }
    public virtual Slot getSlot()
    {
        return this.slot;
    }
    public virtual void putItem(Item item)
    {
        setItem(item);
        setImage(item.getIconImage());

    }
    public virtual void removeItem()
    {
        setItem(null);
        setImage(null);
        item = null;
    }
    public virtual void setItem(Item item)
    {
        this.item = item;
    }
    public virtual Item getItem()
    {
        return this.item;
    }
}
