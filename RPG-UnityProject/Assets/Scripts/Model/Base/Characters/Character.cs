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
    protected Status status = new Status();


    protected Status tempStatus = new Status();

    [Header("ITENS")]
    [SerializeField]
    protected Hand hand;
    [SerializeField]
    protected Equipament equipament;

    protected Head head;

    protected Body body;

    protected CapsuleCollider capsuleCollider;

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
        if(capsuleCollider == null)
        {
            createColliderToGet();
        }
        if(head == null)
        {
            head = GetComponentInChildren<Head>();
        }
        if(body == null)
        {
            body = GetComponentInChildren<Body>();
        }
        // copy status to temp status
        copyStatus();
        status.updateLevel();
        
    }
    protected virtual void copyStatus()
    {
        Status temp = new Status();
        tempStatus.setCharisma(status.getCharisma());
        tempStatus.setDefense(status.getDefense());
        tempStatus.setForce(status.getForce());
        tempStatus.setAgility(status.getAgility());
        tempStatus.setInteligence(status.getInteligence());

    }
    protected virtual void Update()
    {
        setFinalStats();
    }
    protected virtual void mov_run(Vector3 dir) {
       // dir = dir.normalized;
        Vector3 walk = dir * status.getAgility() * 1.3f;
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, walk, Time.deltaTime *15);
    }

    protected virtual void mov_walk(Vector3 dir) {
      //  dir = dir.normalized;
        Vector3 walk = dir * status.getAgility();
        walk.y = rigidbody.velocity.y;
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, walk, Time.deltaTime * 15);
    }
   


    public virtual void hit_take(float hit_damage, Character hitByChar) {
        status.hit_take(hit_damage, hitByChar);
    }
    
    public Status getStatus()
    {
        return status;
    }

    public selfType getSelf()
    {
        return self;
    }
   
    protected virtual void OnTriggerStay(Collider other)
    {
        
    }
    protected virtual void createColliderToGet()
    {
        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.radius = 0.6f;
        capsuleCollider.height = 2;
        Collider collider = capsuleCollider as Collider;
        collider.isTrigger = true;
    }
    protected virtual bool isMySelf(Collider other)
    {
        Collider[] colliders = getAllColliders();
        
        foreach(Collider tempCollider in colliders)
        {
            if(other == tempCollider)
            {
                return true;
            }
        }
        return false;

    }
    protected virtual Collider[] getAllColliders()
    {

        Collider[] colliders = GetComponentsInChildren<Collider>(true);

        return colliders;
    }
    protected virtual void setFinalStats()
    {
        //the stats of player are based in the adition of armor stats plus helmet stats

        float force = tempStatus.getForce();

        float agility = tempStatus.getAgility();

        float charisma = tempStatus.getCharisma();

        float inteligence = tempStatus.getInteligence();

        float defense = tempStatus.getDefense();

        //Armor stats
        if(equipament.getArmorItem() != null)
        {
            force += equipament.getArmorItem().getStats().getForce();
            agility += equipament.getArmorItem().getStats().getAgility();
            charisma += equipament.getArmorItem().getStats().getCharisma();
            inteligence += equipament.getArmorItem().getStats().getInteligence();
            defense += equipament.getArmorItem().getStats().getDefense();
        }
        //Helmet stats
        if (equipament.getHelmetItem() != null)
        {
            force += equipament.getHelmetItem().getStats().getForce();
            agility += equipament.getHelmetItem().getStats().getAgility();
            charisma += equipament.getHelmetItem().getStats().getCharisma();
            inteligence += equipament.getHelmetItem().getStats().getInteligence();
            defense += equipament.getHelmetItem().getStats().getDefense();
        }
        //treatment of variables 
        if(agility <= 1)
        {
            agility = 1;
        }

        status.setForce(force);
        status.setAgility(agility);
        status.setCharisma(charisma);
        status.setInteligence(inteligence);
        status.setDefense(defense);
    }

}
