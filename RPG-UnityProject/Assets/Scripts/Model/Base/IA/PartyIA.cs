using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyIA : BaseIA {

    protected virtual void followPlayer()
    {
        newPositionPatrol = transform.position;
        setStatusIA();
        followObj(playerReference.gameObject);
    }
}
