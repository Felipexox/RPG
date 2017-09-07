using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store{
    [Header("ITEM")]
    [SerializeField]
    protected List<Item> itens = new List<Item>();
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
    public virtual void removeItem(int index)
    {
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
    }
    protected virtual void enableItem(Item item, Transform transform)
    {
        //faz o item aparecer na frente
        // item.transform.position =  transform.position + transform.forward * 1.5f;
        item.transform.position = transform.position;
        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<MeshRenderer>().enabled = true;
    }
}
