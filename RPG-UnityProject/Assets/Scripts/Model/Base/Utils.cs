using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static void disableColliders(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }
    public static void enableColliders(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }
    public static void disableCollider(Collider collider)
    {
        collider.enabled = false;
    }
    public static void enableCollider(Collider collider)
    {
        collider.enabled = true;
    }

}
