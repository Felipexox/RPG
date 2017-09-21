using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIEquipamentManager : InventoryManager {
    public static UIEquipamentManager instance;

    private void Awake()
    {
        instance = this;
    }



    [SerializeField]
    protected UIBody uiBody;
    [SerializeField]
    protected UIHead uiHead;
    [SerializeField]
    protected UIHandRight uiHandRight;
    [SerializeField]
    protected UIHandLeft uiHandLeft;
    private void Start()
    {
        if(uiBody == null)
        {
            uiBody = GetComponentInChildren<UIBody>();
        }
        if (uiHead == null)
        {
            uiHead = GetComponentInChildren<UIHead>();
        }
        if (uiHandRight == null)
        {
            uiHandRight = GetComponentInChildren<UIHandRight>();
        }
        if (uiHandLeft == null)
        {
            uiHandLeft = GetComponentInChildren<UIHandLeft>();
        }
    }

    public Item getItemHandRight() { return uiHandRight.getItem(); }

    public Item getItemHandLeft() { return uiHandLeft.getItem(); }

    public Item getItemHead() { return uiHead.getItem(); }

    public Item getItemBody() { return uiBody.getItem(); }

    public void putItemHandRight(Item item)
    {
        uiHandRight.putItem(item);
    }

    public void putItemHandLeft(Item item)
    {
        uiHandLeft.putItem(item);
    }

    public void putItemHelmet(Item item)
    {
        uiHead.putItem(item);
    }

    public void putItemArmor(Item item)
    {
        uiBody.putItem(item);
    }

    public void removeItemHelmet()
    {
        if (uiHead.getItem() != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.addItemToBag(uiHead.getItem());
            uiHead.getItem().transform.parent = null;
            player.removeHelmetEquipament();
            uiHead.removeItem();
        }
    }

    public void removeItemArmor()
    {

        if (uiBody.getItem() != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.addItemToBag(uiBody.getItem());
            uiBody.getItem().transform.parent = null;
            player.removeArmorEquipament();
            uiBody.removeItem();
        }
    }

    public void removeItemHandRight()
    {
        if (uiHandRight.getItem() != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.addItemToBag(uiHandRight.getItem());
            uiHandRight.getItem().transform.parent = null;
            uiHandRight.removeItem();
        }
    }
    public void desableItemHandRight()
    {
        if (uiHandRight.getItem() != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            uiHandRight.getItem().transform.parent = null;
            uiHandRight.removeItem();
        }
    }
    public void removeItemHandLeft()
    {
        if (uiHandLeft.getItem() != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.addItemToBag(uiHandLeft.getItem());
            uiHandLeft.getItem().transform.parent = null;
            uiHandLeft.removeItem();
        }
    }

}
