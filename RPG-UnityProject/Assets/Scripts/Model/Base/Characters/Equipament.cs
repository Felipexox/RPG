using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Equipament {
    [Header("Equipped")]
    [SerializeField]
    protected Props armor;
    [SerializeField]
    protected Props helmet;

    public void setArmorItem(Item armor)
    {
        this.armor = (Props)armor;
      
    }
    public void setHelmetItem(Item helmet)
    {

        this.helmet = (Props)helmet;
    }
    public Props getArmorItem()
    {
        return this.armor;
    }
    public Props getHelmetItem()
    {
        return this.helmet;
    }
}
