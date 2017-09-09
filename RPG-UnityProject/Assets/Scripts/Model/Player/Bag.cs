using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Bag : Store {

  
    public Bag()
    {
        //     createSlot(size);
        getAllSlotsFromInventory();
        updateInventory();
    }
    private void getAllSlotsFromInventory()
    {
     
        //get all images from the invetory
        for (int i = 0; i < size; i++) {
          
        //    itensSlots.Add(new Slot());
        }
    }
    public void updateInventory()
    {
        for(int i = 0; i < itens.Count; i++)
        {
         
        }
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
            updateInventory();
        return canAdd;

    }
    public override void removeItem(int index)
    {
  
         base.removeItem(index);
         updateInventory();
      
    }

}
