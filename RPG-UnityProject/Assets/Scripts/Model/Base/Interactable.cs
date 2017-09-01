﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    bool isFocus = false, hasInteracted = false;
    Transform player;
    public GameObject play;

    private void Start()
    {
        OnFocus(play.transform);
    }
    private void Update()
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
    public void OnFocus(Transform playertransf) // Utilizado quando o jogador clicar no objeto interativo
    {
        isFocus = true;
        player = playertransf;
        hasInteracted = false;
    }
    public void OnDefocus() // Utilizado quando o jogado clicar em algo que não seja o objeto interativo
    {
        isFocus = false;
        hasInteracted = false;
    }
    private void OnDrawGizmos() // Ver a area de alcance para realizar a interação e bem bonitinho
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

}
