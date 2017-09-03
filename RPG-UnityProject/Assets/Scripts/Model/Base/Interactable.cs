using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [SerializeField]
    protected float radius = 3f, distance;
    protected bool hasInteracted = false;
    protected Transform playerTransform;
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }
    protected virtual void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
        if (!hasInteracted)
        {
            if (distance <= radius)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interaction();
                    hasInteracted = true;
                }
            }

        }
    }
    protected virtual void ReInteract()
    {
        hasInteracted = false;
    }
    protected virtual void Interaction()
    {

    }
    protected virtual void OnDrawGizmos() // Ver a area de alcance para realizar a interação e bem bonitinho
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

}
