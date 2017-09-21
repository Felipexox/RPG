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
    [SerializeField]
    protected float defense;

    private float maxLife;
    public Status()
    {
        maxLife = life;
    }
    public float getLife() { return this.life; }

    public virtual void hit_take(float hit_damage)
    {
        this.life -= (hit_damage - defense);
    }

    public float getAgility() { return this.agility; }

    public float getInteligence() { return this.inteligence; }

    public float getCharisma() { return this.charisma; }

    public float getForce() { return this.force; }
    
    public float getDefense() { return this.defense; }



    public void setLife(float life) { this.life = life; }

    public void addLife(float life) {

        this.life += life;
        if(this.life > maxLife)
        {
            this.life = maxLife;
        }
    }

    public void setAgility(float agility) { this.agility = agility; }

    public void addAgility(float agility) { this.agility += agility; }

    public void setInteligence(float inteligence) { this.inteligence = inteligence; }

    public void setCharisma(float charisma) { this.charisma = charisma; }

    public void setForce(float force) { this.force = force; }
    
    public void addForce(float force) { this.force += force; }

    public void setDefense(float defense) { this.defense = defense; }
}