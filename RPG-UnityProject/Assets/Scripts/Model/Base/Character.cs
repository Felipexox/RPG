using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character:MonoBehaviour  {

    [Header("INFO CHARACTER")]
    [SerializeField]
    protected string name;
    [Header("STATUS")]
    [SerializeField]
    protected double life;
    [SerializeField]
    protected double force;
    [SerializeField]
    protected double velocity;
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

    protected virtual void mov_run() { }

    protected virtual void mov_walk() { }
   


    public virtual void hit_take(double hit_damage) { }
    
    public double dano_by_status_fisico()
    {
        double dano = 0;
        dano = (force * (velocity / 3)) / 10;
        return dano;
    }
    


    public double getVida() { return this.life; }

    public double getVelocity() { return this.velocity; }

    public string getName() { return this.name; }

    public double getCharisma() { return this.charisma; }

    public double getForce() { return this.force; }
}
