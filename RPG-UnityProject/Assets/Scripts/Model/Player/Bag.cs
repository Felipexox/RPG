﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Bag : Store {
    private GameObject inventoryUI;
    public void setInventoryUI(GameObject inventoryUI)
    {
        this.inventoryUI = inventoryUI;
    }
   
    private void getAllSlotsFromInventory()
    {
        Slot[] tempSlots = inventoryUI.transform.GetChild(0).GetComponentsInChildren<Slot>();
        //get all images from the invetory
        for (int i = 0; i < size; i++) {


            slots.Add(tempSlots[i]);
        }
    }
    private void updateUI()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if (i < itens.Count && itens.Count != 0)
            {
                // make the ui of inventory update of realy itens in bag
                slots[i].setIdSlot(i);
                slots[i].setIcon(itens[i].getIconImage());
                slots[i].activeItem();
            }else
            {
                
            
                slots[i].deactive();
            }
        }
    }
    public void updateInventory()
    {
        getAllSlotsFromInventory();
    }
    public void createSlot(int numberSlots)
    {
        Transform inventory = GameObject.FindGameObjectWithTag("Inventory").transform;
        for(int i = 0; i< numberSlots; i++)
        {
     //       GameObject tempSlot = GameObject.Instantiate(slotPrefab);
        //    tempSlot.transform.parent = inventory;

        }
    }
    public override bool addItem(Item item)
    {
        bool canAdd = base.addItem(item);
        if (canAdd)
            updateUI();
        return canAdd;

    }
    public override void removeItem(int index, Transform trans)
    {

         base.removeItem(index, trans);
         updateUI();
      
    }
    
    public void removeItemAtSlot(int index)
    {
        if (itens.Count > index)
        {
            itens.RemoveAt(index);
          
        }
        updateUI();
    }
    public Item holdItem(int indexItem, Transform handTransform)
    {
        //desable physics and colliders and enable trigger to hit other characters
        Collider collider = itens[indexItem].GetComponent<Collider>();
        collider.enabled = false;
        collider.isTrigger = true;
        itens[indexItem].GetComponent<Rigidbody>().isKinematic = true;

        setItemMeshActive(itens[indexItem], true);

        setItemParent(indexItem, handTransform);
        setDefaultTransform(itens[indexItem].transform);

        return itens[indexItem];
    }
   
   

}
