using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour {
    public enum typeConsumable
    {
        FOOD,
        DRINK,
        POTION,
    }
    [Header("STATUS")]
    [SerializeField]
    protected double modLife;
    [SerializeField]
    protected double modForce;
    [SerializeField]
    protected float modVelocity;
    [Header("Consumable Type")]
    [SerializeField]
    protected typeConsumable consumType;

}
