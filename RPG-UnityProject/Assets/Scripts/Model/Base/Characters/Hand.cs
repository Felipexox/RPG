using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    [SerializeField]
    private Character myChar;
    private Animator animator;
    [SerializeField]
    private Item itemInHand;
    private void Start()
    {
        myChar = GetComponentInParent<Character>();
        animator = GetComponent<Animator>();
    }

    public Character getMyChar()
    {
        return myChar;
    }
    public void playAction1()
    {
        Item item = transform.GetChild(0).GetComponentInChildren<Item>();
        Weapon weapon = transform.GetChild(0).GetComponentInChildren<Weapon>();

        if (weapon != null) {
          //  Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"));
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"))
            {
                itemInHand = weapon;
                weapon.hit_weak(myChar.getStatus());
                int idAnimation = Random.Range(1, 2);
                string animationName = weapon.getNameItem() + "Hit_1";
            //    Debug.Log(animationName);
                animator.Play(animationName);
            }
        }
        else
        {
            if(item != null)
            {
                itemInHand = item;
              // interação de item
            }
        }
    }
    public void playAction2()
    {
        Item item = GetComponentInChildren<Item>();
        Weapon weapon = GetComponentInChildren<Weapon>();
        if (weapon != null)
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"));
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"))
            {
                itemInHand = weapon;
                weapon.hit_weak(myChar.getStatus());
                int idAnimation = Random.Range(1, 2);
                string animationName = weapon.getNameItem() + "Hit_2";
                Debug.Log(animationName);
                animator.Play(animationName);
            }
        }
        else
        {
            if (item != null)
            {
                itemInHand = item;
                // interação de item
            }
        }
    }

}
