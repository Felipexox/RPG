using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class InventoryManager : MonoBehaviour {
    [SerializeField]
    private bool activeInventory;
    public static InventoryManager intance;
    private void Awake()
    {
        intance = this;
    }
    private void Update()
    {
       // setActiveInventory(activeInventory);
    }
    public void setActiveInventory(bool isActive)
    {
 
        Image currentImage = GetComponent<Image>();

        currentImage.enabled = isActive;
        findTransformsChilds(transform, isActive);
        
    }
    private void setImageActiveChilds(Transform[] objs, bool isActive)
    {
        for(int i = 0; i < objs.Length; i++)
        {
            Image[] images = objs[i].GetComponentsInChildren<Image>();
            Text[] texts = objs[i].GetComponentsInChildren<Text>();
            for(int j = 0; j < images.Length; j++)
            {
                images[j].enabled = isActive;
            }
            for(int k = 0; k < texts.Length; k++)
            {
                texts[k].enabled = isActive;
            }
            findTransformsChilds(objs[i], isActive);
        }
    }
    private void findTransformsChilds(Transform obj, bool isActive)
    {
        List<Transform> transforms = new List<Transform>();
        int length = obj.childCount;
        for(int i = 0; i < length; i++)
        {
            transforms.Add(obj.GetChild(i));
        }
        setImageActiveChilds(transforms.ToArray(),isActive );
    }
    
}
