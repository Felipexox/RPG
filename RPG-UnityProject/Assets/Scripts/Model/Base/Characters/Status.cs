using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
 
    [Header("STATUS")]
    [SerializeField]
    protected float life;
    [SerializeField]
    protected float force;
    [SerializeField]
    protected float agility;
    [SerializeField]
    protected float charisma;
    [SerializeField]
    protected float inteligence;


    public float getLife() { return this.life; }

    public virtual void hit_take(float hit_damage)
    {
        this.life -= hit_damage;
    }

    public float getAgility() { return this.agility; }

    public float getInteligence() { return this.inteligence; }

    public float getCharisma() { return this.charisma; }

    public float getForce() { return this.force; }
}