using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {
    [SerializeField]
    private  GameObject slotPrefab;
    public void createSlot(Transform parent)
    {
        GameObject tempSlot = (GameObject)Instantiate(slotPrefab);
        tempSlot.transform.parent = parent;
    }
	
}
