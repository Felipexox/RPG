using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIList : MonoBehaviour {
    protected Item[] listImage;

    public virtual Item[] getAllInventoryItens()
    {
        return listImage;
    }
    
 
}
