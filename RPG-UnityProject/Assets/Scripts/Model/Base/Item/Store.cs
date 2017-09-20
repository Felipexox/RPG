using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store{
    [Header("ITEM")]
    [SerializeField]
    protected List<Item> itens = new List<Item>();
    [SerializeField]
    protected List<Slot> slots = new List<Slot>();
    [Header("Size Store")]
    [SerializeField]
    protected int size;
    
    

    public virtual bool addItem(Item item)
    {
        if (itens.Count < size)
        {
            itens.Add(item);
            desableItem(item);
            
            return true;
        }
        else
        {
            return false;
        }

    }
    public virtual void removeItem(int index,Transform transform)
    {
        Debug.Log("Item removed at position: "+index);
  
        if (itens.Count > index)
        {
            dropItem(index, transform);
            itens.RemoveAt(index);
        }

    }
    public virtual List<Item> getItens()
    {
        return this.itens;
    }
    public virtual void setSize(int size)
    {
        this.size = size;
    }
    protected virtual void desableItem(Item item)
    {
        setItemMeshActive(item, false);

        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
    }
   
    protected virtual void enableItem(int itemIndex, Transform transform)
    {
        // active the components in item to do this enable
        // item.transform.position =  transform.position + transform.forward * 1.5f;
        itens[itemIndex].transform.position = transform.position + transform.forward * transform.lossyScale.x * 0.5f;

        //active the mesh
        setItemMeshActive(itens[itemIndex], true);
        //active the colliders with default states 
        Collider collider = itens[itemIndex].GetComponent<Collider>();
        collider.enabled = true;
        collider.isTrigger = false;
        //set the physics 
        itens[itemIndex].GetComponent<Rigidbody>().isKinematic = false;
     
       
    }
    public virtual void dropItem(int indexItem, Transform transform)
    {

        //active the item in front of Transform
        enableItem(indexItem, transform);
        //set the parent of item to null, for this getout of others objects
        setItemParent(indexItem, null);


    }
    protected virtual void setItemMeshActive(Item item,bool isActive)
    {
        //active the mesh of all component
        if (item != null)
        {
            MeshRenderer currentMesh = item.gameObject.GetComponent<MeshRenderer>();
            if (currentMesh != null)
            {
                item.GetComponent<MeshRenderer>().enabled = false;

            }
            MeshRenderer[] meshs = item.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshs.Length; i++)
            {
                meshs[i].enabled = isActive;
            }
        }

    }
    protected virtual void setDefaultTransform(Transform transform)
    {
        //set default transform for a component
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles =  Vector3.zero;
     

    }
    public virtual void setItemParent(int index, Transform parent)
    {
        //set the parent item by the parameter 
        itens[index].transform.parent = parent;
    }
    public virtual void setItemParent(Item item, Transform parent)
    {
        //set the parent item by the parameter 
        item.transform.parent = parent;
    }

    public virtual Item getItem(int index)
    {
        return this.itens[index];
    }
}
