using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum typeItem
    {
        POTION,
        WEAPON

    }
    [Header("ITEM INFO")]
    [SerializeField]
    protected typeItem itemType;
    [Header("INFO")]
    [SerializeField]
    protected string name;
    [SerializeField]
    protected double durability;
	

}
