using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public enum typeWeapons{
        MAGIC,
        PHYSICIST,
        SHIELD

    }
  

    [SerializeField]
    protected typeWeapons type;
    
    [Header("STATUS")]
    [SerializeField]
    protected double magicDamage;

    [SerializeField]
    protected double physicistDamage;

    [SerializeField]
    protected double cuttingDamage;

    

    protected virtual void hit_stronger() { }

    protected virtual void hit_weak() { }
}
