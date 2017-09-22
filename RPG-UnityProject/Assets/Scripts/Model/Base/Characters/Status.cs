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
    protected float experience;
    [SerializeField]
    protected int level = 1;
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


    private float experieceNeeded = 70;

    private float lastExperienceNeeded;

    private int pointsToAdd;

    protected float maxLife;

    public virtual void startLife()
    {
        maxLife = life;
    }

    public virtual void hit_take(float hit_damage, Character hitByChar)
    {
     
        this.life -= (hit_damage - defense);
        
        //if character is dead
        if(this.life <= 0)
        {
            isDead(hitByChar);
        }
    }

    public bool isDead(Character hitByChar)
    {
        if(this.life <= 0)
        {
            hitByChar.getStatus().addExperience(experience);
            return true;
        }else
        {
            return false;
        }
    }

    public void removePointsToAdd()
    {
        pointsToAdd--;
    }

    public void addAgility(float agility) { this.agility += agility; }

    public void addForce(float force) { this.force += force; }

    public void addMaxLife(float life)
    {
        this.maxLife += life;
    }

    public void addLife(float life)
    {

        this.life += life;
        if (this.life > maxLife)
        {
            this.life = maxLife;
        }
    }

    public void addCharisma(float charisma)
    {
        this.charisma += charisma;
    }

    public void addDefense(float defense)
    {
        this.defense += defense;
    }

    public void addInteligence(float inteligence)
    {
        this.inteligence += inteligence;
    }

    public void setLevelByExperience()
    {
        //Level plus plus for level update
        this.level++;
        //the current is equals experience subtracted of needed experience
        experience -= experieceNeeded;
        lastExperienceNeeded = experieceNeeded;
        //the new level experience needed is current experience multiplication by 1.6f
        experieceNeeded *= 1.6f;
        pointsToAdd++;
      

    }

    public void addExperience(float experience)
    {
        this.experience += experience;
        if(this.experience >= experieceNeeded)
        {
            updateLevel();
        }
    }

    public void updateLevel()
    {
        while(experience >= experieceNeeded)
        {
            setLevelByExperience();
        }
    }

    public float getAllExperience()
    {
        float tempExperience = level != 1 ? (lastExperienceNeeded + experience) : experience;
        return tempExperience;
    }

    public int getPointsToAdd()
    {
        return pointsToAdd;
    }

    public bool havePointsToAdd()
    {
        return pointsToAdd > 0;
    }

    #region gets methods

    public float getLife() { return this.life; }

    public float getMaxLife() { return this.maxLife; }

    public float getExperience() { return this.experience; }

    public int getLevel() { return this.level; }

    public float getAgility() { return this.agility; }

    public float getInteligence() { return this.inteligence; }

    public float getCharisma() { return this.charisma; }

    public float getForce() { return this.force; }
    
    public float getDefense() { return this.defense; }

    #endregion

    #region set methods

    public void setLife(float life) { this.life = life; }

    public void setMaxLife(float maxLife) { this.maxLife = maxLife; }

    public void setExperience(float experience) { this.experience = experience; }

    public void setLevel(int level) { this.level = level; }

    public void setAgility(float agility) { this.agility = agility; }

    public void setInteligence(float inteligence) { this.inteligence = inteligence; }

    public void setCharisma(float charisma) { this.charisma = charisma; }

    public void setForce(float force) { this.force = force; }
    
 
    public void setDefense(float defense) { this.defense = defense; }


    #endregion
}