using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : Item {
    public enum typeConsumable
    {
        FOOD,
        DRINK,
        POTION,
    }
    [Header("STATUS")]
    [SerializeField]
    protected float modLife;
    [SerializeField]
    protected float modForce;
    [SerializeField]
    protected float modVelocity;
    [Header("Consumable Type")]
    [SerializeField]
    protected typeConsumable consumType;
    
    public void setModLife(float modLife)
    {
        this.modLife = modLife;
    }
    public void setModeForce(float modForce)
    {
        this.modForce = modForce;
    }
    public void setModVelocity(float modVelocity)
    {
        this.modVelocity = modVelocity;
    }
    public void setTypeConsumable(typeConsumable type)
    {
        this.consumType = type;
    }

    public float getModLife()
    {
        return this.modLife;
    }
    public float getModeForce()
    {
        return this.modForce;
    }
    public float getModVelocity()
    {
        return this.modVelocity;
    }
    public typeConsumable getTypeConsumable()
    {
        return this.consumType;
    }
}
