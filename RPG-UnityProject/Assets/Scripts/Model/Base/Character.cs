using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Character:MonoBehaviour  {

    [Header("INFO CHARACTER")]
    [SerializeField]
    protected string nameCharacter;
    [Header("STATUS")]
    [SerializeField]
    protected float life;
    [SerializeField]
    protected float force;
    [SerializeField]
    protected float velocity;
    [SerializeField]
    protected double charisma;
    [Header("ITENS")]
    [SerializeField]
    protected Weapon weaponInHand;

    [SerializeField]
    protected List<Item> itens;
    protected Rigidbody rigidbody;

    protected virtual void Start()
    {
        if(rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    protected virtual void mov_run(Vector3 dir) {
        dir = dir.normalized;
        Vector3 walk = dir * velocity * 1.3f;
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = walk;
    }

    protected virtual void mov_walk(Vector3 dir) {
        dir = dir.normalized;
        Vector3 walk = dir * velocity;
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = walk;
    }
   


    public virtual void hit_take(float hit_damage) {
        this.life -= hit_damage;
    }
    
    public float dano_by_status_fisico()
    {
        float dano = 0;
        dano = (force * (velocity / 3)) / 10;
        return dano;
    }
    


    public double getVida() { return this.life; }

    public float getVelocity() { return this.velocity; }

    public string getName() { return this.name; }

    public double getCharisma() { return this.charisma; }

    public double getForce() { return this.force; }
   
}
