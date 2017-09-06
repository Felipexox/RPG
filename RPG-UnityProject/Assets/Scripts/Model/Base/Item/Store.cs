using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {
    [Header("Status")]
    [SerializeField]
    protected int qtdMaxDeItens;
    protected List<Item> Itens;
    protected virtual void AddItem(Item it)
    {
        if(Itens.Count < qtdMaxDeItens)
            Itens.Add(it);
    }
    protected virtual Item RemoveItem(int id)
    {
        Item it = Itens[id];
        Itens.RemoveAt(id);
        return it;
    }
	// Use this for initialization
}
