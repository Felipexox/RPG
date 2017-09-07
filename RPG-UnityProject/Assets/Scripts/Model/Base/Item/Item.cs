using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum typeItem
    {
        CONSUMABLE,
        WEAPON,
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
    protected double durability;

    public virtual string getNameItem()
    {
        return nameItem;
    }

    public virtual Item getItem()
    {
        return this;
    }

}
