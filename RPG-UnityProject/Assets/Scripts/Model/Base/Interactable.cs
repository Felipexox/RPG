using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [SerializeField]
    protected float radius = 3f;
    protected bool isFocus = false, hasInteracted = false;
    protected Transform player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        OnFocus(player);
    }
    protected virtual void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("Interacting"); // Interação
                hasInteracted = true;
            }

        }
    }
    protected virtual void OnFocus(Transform playertransf) // Utilizado quando o jogador clicar no objeto interativo
    {
        isFocus = true;
        player = playertransf;
        hasInteracted = false;
    }
    protected virtual void OnDefocus() // Utilizado quando o jogado clicar em algo que não seja o objeto interativo
    {
        isFocus = false;
        hasInteracted = false;
    }
    protected virtual void OnDrawGizmos() // Ver a area de alcance para realizar a interação e bem bonitinho
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

}
