using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : Item {
     public enum TypeProps
    {
        ARMOR,
        HELMET
    };
    [SerializeField]
    protected TypeProps typeProps;
    [Header("Property")]
    [SerializeField]
    protected Status stats;
    [SerializeField]
    public TypeProps getTypeProps()
    {
        return typeProps;
    }
    public Status getStats()
    {
        return this.stats;
    }

}
