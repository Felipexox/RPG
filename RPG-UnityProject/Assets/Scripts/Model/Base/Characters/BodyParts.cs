using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour {
    [SerializeField]
    protected Character myChar;
    protected Animator animator;
    protected virtual void Start()
    {
        myChar = GetComponentInParent<Character>();
        animator = GetComponent<Animator>();
    }
    public virtual Character getMyChar()
    {
        return myChar;
    }
}
