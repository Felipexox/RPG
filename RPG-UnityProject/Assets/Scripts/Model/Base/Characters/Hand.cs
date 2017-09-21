using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : BodyParts {
   
  
    [SerializeField]
    private Item itemInHand;
  

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
    public void eventConsume()
    {
        if (itemInHand != null)
        {
            Player player = (Player)myChar;
            player.itemConsume((Consumables)itemInHand.getItem());
        }
    }
    public void consume()
    {
        Item item = GetComponentInChildren<Item>();
        Consumables consumable = GetComponentInChildren<Consumables>();
        if (consumable != null)
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"));
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("HandIdle"))
            {
                itemInHand = consumable;
                
                int idAnimation = Random.Range(1, 2);
                string animationName =  "Consume";
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
    public Item getItem()
    {
        return this.itemInHand;
    }
    public void setItem(Item item)
    {
        this.itemInHand = item;
    }
}
