using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour {
    [Header("Item Info")]
    [SerializeField]
    protected string name;

    [SerializeField]
    protected Item.typeItem typeItem;

    [SerializeField]
    protected float durability;

    [SerializeField]
    protected Sprite iconImage;

    [Header("Weapon Item")]

    [SerializeField]
    protected Weapon.typeWeapons typeWeapon;

    [SerializeField]
    protected float magicDamage;

    [SerializeField]
    protected float physicDamage;

    [SerializeField]
    protected float cuttingDamage;

    [Header("Consumable Item")]
    [SerializeField]
    protected float modLife;
    [SerializeField]
    protected float modForce;
    [SerializeField]
    protected float modVelocity;
    [SerializeField]
    protected Consumables.typeConsumable consumType;


    [Header("Model")]
    [SerializeField]
    protected GameObject model3D;
   
    

    public void createItem()
    {
        GameObject itemObj = (GameObject)Instantiate(model3D, Vector3.zero, model3D.transform.rotation);
        itemObj.name = name;
        if (typeItem == Item.typeItem.WEAPON)
        {

            Weapon weaponScript = itemObj.AddComponent<Weapon>();
            editWeapon(weaponScript);
        }
        else
        {
            if(typeItem == Item.typeItem.CONSUMABLE)
            {

            }
        }

       
    }
    //set the params to the object of type weapon
    private void editWeapon(Weapon weapon)
    {
        weapon.setName(name);
        weapon.setTypeItem(Item.typeItem.WEAPON);
        weapon.setDurability(durability);
        weapon.setTypeWeapon(typeWeapon);
        weapon.setPhysicDamage(physicDamage);
        weapon.setMagicDamage(magicDamage);
        weapon.setCuttingDamage(cuttingDamage);
        weapon.setIconImage(iconImage);
    }
    //set the params to the object consumable
    private void editConsumible(Consumables consumables)
    {
        consumables.setTypeItem(Item.typeItem.CONSUMABLE);
        consumables.setModVelocity(modVelocity);
        consumables.setModLife(modLife);
        consumables.setModeForce(modForce);
        consumables.setTypeConsumable(consumType);
        consumables.setIconImage(iconImage);
    }
}
