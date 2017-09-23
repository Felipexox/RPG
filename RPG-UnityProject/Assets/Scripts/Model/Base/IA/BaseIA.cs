using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMesh))]
public class BaseIA : Character {
    [SerializeField]
    protected Player playerReference;
    [Header("Info IA")]
    [SerializeField]
    protected GameObject target;
    [SerializeField]
    protected Vector3 newPositionPatrol;
    [SerializeField]
    protected float maxDistanceToPatrol;
    [SerializeField]
    protected bool inFight;
   
    protected NavMeshAgent navMesh;

    protected virtual void Awake()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        navMesh = GetComponent<NavMeshAgent>();
        setStatusIA();
    }

    protected virtual void idleMove(Vector3 origin)
    {
       
        float distance = navMesh.remainingDistance;
        navMesh.speed = 1;
        if (distance < 1)
        {

            Vector3 newPosition = randomPositionAround(origin);
            newPositionPatrol = newPosition;
        }
        followVector(newPositionPatrol);
    }

    protected virtual Vector3 randomPositionAround(Vector3 origin)
    {
        Random.seed = Time.time.ToString().GetHashCode();
        RaycastHit hit;
        Vector3 newPosition;
        int i = 0;
        do
        {
   
            //direction on the x-axis 
            float x = (Random.value * Random.Range(-10, 10));
            //direction on the y-axis
            float z = (Random.value * Random.Range(-10, 10));
            //module of vetor result
            float module = Mathf.Sqrt((x * x) + (z * z));
            newPosition = new Vector3(x / module, 0, z / module);

            Ray ray = new Ray(transform.position, newPosition);

            Physics.Raycast(ray, out hit, maxDistanceToPatrol);
            if (hit.collider != null)
                Debug.Log(hit.collider.name);
            i++;

        } while (i < 3 && hit.collider != null);
        newPosition *= maxDistanceToPatrol;
        return newPosition+origin;
    }

    protected virtual void setStatusIA()
    {
        navMesh.speed = getStatus().getAgility();
    }

    public virtual GameObject getTarget()
    {
        return this.target;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    protected virtual void followTarget()
    {
        if(this.target != null)
        {
            followObj(target);
        }
    }

    protected virtual void followObj(GameObject obj)
    {
        navMesh.SetDestination(obj.transform.position);
    }

    protected virtual void followVector(Vector3 vector)
    {
        navMesh.destination = (vector);
    }

    protected virtual bool getIsFight()
    {
        return this.inFight;
    }

}
