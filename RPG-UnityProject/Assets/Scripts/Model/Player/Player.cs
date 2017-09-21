﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
 
    private UtilsCamera cam;
    [SerializeField]
    private Bag bag;
    private bool isActiveInventory = false;

    protected override void Start()
    {
        base.Start();
      //  Cursor.visible = false;
        if(cam == null)
        {
            cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<UtilsCamera>();
        }
        setInventory();
        bag.updateInventory();
        setActiveUI(false);

    }
    private void Update()
    {
        base.Update();
        if (!isActiveInventory)
        {
            move_controller();
            attack_controller();
            cam.resumeCamera();
        }else
        {
            cam.pauseCamera();
        }
        inventoryController();
        
    }
   
 
    private void FixedUpdate()
    {
        rotation_controller();
    }
  
    private bool canGetItem = true;
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);

        if (!isMySelf(other))
        {
            if (canGetItem)
            {
                Item otherItem = other.GetComponent<Item>();
                if (otherItem != null)
                {
                    // Debug.Log(other.name);
                    //  Debug.Log(canGetItem);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // when you press E canGetItem get the value false while you not Up your finger of buttom
                        addItemToBag(otherItem);

                        canGetItem = false;
                    }
                    
               }
            }
            if (Input.GetKeyUp(KeyCode.E)) { 
                canGetItem = true;
            }
        }
    }
 
  
    #region Player Controllers

    void move_controller()
    {
        float x = Input.GetAxisRaw("Horizontal") * 0.8f;
        float z = Input.GetAxisRaw("Vertical");
        z = z < 0 ? z * 0.8f : z;

        //  Vector3 cameraDir = cam.getDir().normalized;

        //   Vector3 dir = (cameraDir * z) + (transform.right * x);
        Vector3 dir = (transform.forward * z) + (transform.right * x);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mov_run(dir);
        }
        else
        {
            mov_walk(dir);
        }
    }
    void attack_controller()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hand.playAction1();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                hand.playAction2();
            }
        }
    }
    void rotation_controller()
    {
        Quaternion lookTo = Quaternion.LookRotation(cam.getDir());
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTo, 0.2f);
    }

    void inventoryController()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            isActiveInventory = !isActiveInventory;
            setActiveUI(isActiveInventory);

        }

    }

    #endregion

    #region Inventory Interactions

    private void setInventory()
    {

        GameObject inventoryUIObject = InventoryManager.intance.gameObject;
        Debug.Log(inventoryUIObject.name);
        bag.setInventoryUI(inventoryUIObject);

    }


    public void holdItemFromBag(int index)
    {
     
        if (UIEquipamentManager.instance.getItemHandRight() != null)
        {

            UIEquipamentManager.instance.removeItemHandRight();

        }
        Item item = bag.setItemInBody(index, hand.transform.GetChild(0));
        hand.setItem(item);
        bag.removeItemAtSlot(index);
        UIEquipamentManager.instance.putItemHandRight(item);
        

    }

    public void equipItemFromBag(int index)
    {
      
            Item item = bag.getItem(index);
            if (item.GetComponent<Props>().getTypeProps() == Props.TypeProps.HELMET)
            {

                if (UIEquipamentManager.instance.getItemHead() != null)
                {
                    
                    UIEquipamentManager.instance.removeItemHelmet();

                }
                Item helmetItem = bag.setItemInBody(index, head.transform);
                equipament.setHelmetItem(helmetItem);

                bag.removeItemAtSlot(index);
                UIEquipamentManager.instance.putItemHelmet(helmetItem);

            }
            if (item.GetComponent<Props>().getTypeProps() == Props.TypeProps.ARMOR)
            {
                if (UIEquipamentManager.instance.getItemBody() != null)
                {

                    UIEquipamentManager.instance.removeItemArmor();

                }
                Item armorItem = bag.setItemInBody(index, body.transform);
                equipament.setArmorItem(armorItem);

                bag.removeItemAtSlot(index);
                UIEquipamentManager.instance.putItemArmor(armorItem);

            }
        
    }

    public void removeItemFromBag(int index)
    {
        bag.removeItem(index, transform);
    }
    
   
    void setActiveUI(bool isActive)
    {
        InventoryManager.intance.setActiveInventory(isActive);
        UIEquipamentManager.instance.setActiveInventory(isActive);
    }

    public void removeHelmetEquipament()
    {
        equipament.setHelmetItem(null);
    }

    public void removeArmorEquipament()
    {
        equipament.setArmorItem(null);
    }

    public void addItemToBag(Item item)
    {

        bag.addItem(item);
    }
    #endregion
}
