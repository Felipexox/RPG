using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public enum typeWeapons{
        MAGIC,
        PHYSIC,
        SHIELD

    }
  

    [SerializeField]
    protected typeWeapons type;
    
    [Header("STATUS")]
    [SerializeField]
    protected float magicDamage;

    [SerializeField]
    protected float physicDamage;

    [SerializeField]
    protected float cuttingDamage;

    [SerializeField]
    protected float full_damage;

    protected List<GameObject> list_do_hit = new List<GameObject>();

    public virtual void hit_stronger(Status stats) {
        //zerar lista de hits depois do combo
        list_do_hit = new List<GameObject>();

        Collider collider = GetComponentInChildren<Collider>();

        //Turn on the colliders for make the hit in enemy
        Utils.enableCollider(collider);

        //The full damage is a variable for make the event in the collider take damage multiply by 1.5f
        full_damage = (magicDamage + physicDamage + cuttingDamage) * 1.5f;
    }

    public virtual void hit_weak(Status stats) {
        //zerar lista de hits depois do combo
        list_do_hit = new List<GameObject>();

        Collider collider = GetComponentInChildren<Collider>();

        //Turn on the colliders for make the hit in enemy
        Utils.enableCollider(collider);

        //The full damage is a variable for make the event in the collider take damage
        full_damage = (magicDamage + physicDamage + cuttingDamage);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Get the character who take hit and check if this is not yourself
        Character otherCharScript = other.GetComponent<Character>();
        Hand myHandScript = transform.GetComponentInParent<Hand>();
        if (otherCharScript != null && myHandScript != null)
        {
            if (otherCharScript.getSelf() != myHandScript.getMyChar().getSelf() && !isDoHit(other.gameObject))
            {
                otherCharScript.hit_take(physicDamage + magicDamage + cuttingDamage, myHandScript.getMyChar());
                list_do_hit.Add(otherCharScript.gameObject);
            }
        }
    }

    protected virtual bool isDoHit(GameObject enemy)
    {
        foreach (GameObject tempEnemy in list_do_hit)
        {
            if(tempEnemy == enemy)
            {
                return true;
            }
        }
        return false;
    }
    
    public void setTypeWeapon(typeWeapons type)
    {
        this.type = type;
    }
    public void setMagicDamage(float magicDamage)
    {
        this.magicDamage = magicDamage;
    }
    public void setPhysicDamage(float physicDamage)
    {
        this.physicDamage = physicDamage;
    }
    public void setCuttingDamage(float cuttingDamage)
    {
        this.cuttingDamage = cuttingDamage;
    }
}
