using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Character:MonoBehaviour  {
    public enum selfType
    {
        BAD_GUY,
        GOOD_GUY
    }
    [Header("INFO CHARACTER")]
    [SerializeField]
    protected string nameCharacter;
    [SerializeField]
    protected selfType self;
    [SerializeField]
    protected Status status;
    [Header("ITENS")]
    [SerializeField]
    protected Hand hand;

    [SerializeField]
    protected List<Item> itens;
    protected Rigidbody rigidbody;

    protected virtual void Start()
    {
        if(hand == null)
        {
            hand = GetComponentInChildren<Hand>();
        }
        if(rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    protected virtual void mov_run(Vector3 dir) {
        dir = dir.normalized;
        Vector3 walk = dir * status.getAgility() * 1.3f;
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, walk, Time.deltaTime *15);
    }

    protected virtual void mov_walk(Vector3 dir) {
        dir = dir.normalized;
        Vector3 walk = dir * status.getAgility();
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, walk, Time.deltaTime * 15);
    }
   


    public virtual void hit_take(float hit_damage) {
        status.hit_take(hit_damage);
    }
    
    public Status getStatus()
    {
        return status;
    }

    public selfType getSelf()
    {
        return self;
    }
   
}
