using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : Interactable {
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (distance > radius)
            ReInteract();

    }
    protected override void Interaction()
    {
        Debug.Log("Teste");
        base.Interaction();

    }

}
