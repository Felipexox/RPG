using System.Collections;
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
        InventoryManager.intance.setActiveInventory(isActiveInventory);

    }
    private void Update()
    {
        if (!isActiveInventory)
        {
            move_controller();
            attack_controller();
            cam.resumeCamera();
        }else
        {
            cam.pauseCamera();
        }
        inventoryManager();
        
    }
    private void setInventory()
    {

        GameObject inventoryUIObject = InventoryManager.intance.gameObject;
        Debug.Log(inventoryUIObject.name);
        bag.setInventoryUI(inventoryUIObject);
    
    }
    public void removeItemFromBag(int index)
    {
        bag.removeItem(index, transform);
    }
    public void holdItemFromBag(int index)
    {

        if (hand.getItem() != null)
        {
            bag.addItem(hand.getItem());
            bag.setItemParent(hand.getItem(), null);

        }

        hand.setItem(bag.holdItem(index, hand.transform.GetChild(0)));
        bag.removeItemAtSlot(index);
     
       
    }
    private void FixedUpdate()
    {
        rotation_controller();
    }
    void move_controller()
    {
        float x = Input.GetAxisRaw("Horizontal") *0.8f;
        float z = Input.GetAxisRaw("Vertical");
        z = z < 0 ? z * 0.8f : z;

        //  Vector3 cameraDir = cam.getDir().normalized;

        //   Vector3 dir = (cameraDir * z) + (transform.right * x);
        Vector3 dir = (transform.forward * z) + (transform.right * x);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mov_run(dir);
        }else
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
              

                        bag.addItem(otherItem);
                        canGetItem = false;
                    }
                    
               }
            }
            if (Input.GetKeyUp(KeyCode.E)) { 
                canGetItem = true;
            }
        }
    }
    void inventoryManager()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
 
            isActiveInventory = !isActiveInventory;
  
            InventoryManager.intance.setActiveInventory(isActiveInventory);
        }
        
    }

}
