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
        /*for(int i = 0; i < itens.Count; i++)
        {
            if(index >= i && index > 0)
            {
                if (i < itens.Count - 1)
                {
                    itens[i] = itens[i + 1];
                    slots[i] = slots[i + 1];
                }
            }else
            {
                if(index == 0)
                {
                    itens.Clear();
           
                }
            }
        }*/
        enableItem(itens[index], transform);
        itens.RemoveAt(index);

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
        item.GetComponent<MeshRenderer>().enabled = false;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
    }
    protected virtual void enableItem(Item item, Transform transform)
    {
        //faz o item aparecer na frente
        // item.transform.position =  transform.position + transform.forward * 1.5f;
        item.transform.position = transform.position + transform.forward * transform.lossyScale.x * 0.5f;
        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<MeshRenderer>().enabled = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
    }
}
