using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum typeItem
    {
        CONSUMABLE,
        WEAPON,
        EQUIPAMENT,
        MISC,
        QUEST_ITENS,

    }
 
    [Header("ITEM INFO")]
    [SerializeField]
    protected typeItem itemType;
    [Header("INFO")]
    [SerializeField]
    protected string nameItem;
    [SerializeField]
    protected float durability;
    [SerializeField]
    protected Sprite iconItem;

    public virtual string getNameItem()
    {
        return nameItem;
    }

    public virtual Item getItem()
    {
        return this;
    }

    public virtual void setName(string name)
    {
        this.nameItem = name;
    }
    public virtual typeItem getTypeItem()
    {
        return this.itemType;
    }
    public virtual void setTypeItem(typeItem type)
    {
        this.itemType = type;
    }
    public virtual void setDurability(float durability)
    {
        this.durability = durability;
    }
    public virtual void setIconImage(Sprite image)
    {
        this.iconItem = image;
    }
    public virtual Sprite getIconImage()
    {
        return this.iconItem;
    }
}
