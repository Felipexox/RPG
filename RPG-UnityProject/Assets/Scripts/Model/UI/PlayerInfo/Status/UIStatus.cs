using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStatus : MonoBehaviour {
    [SerializeField]
    protected Text text;
    [SerializeField]
    protected GameObject buttomAdd;
    public virtual void Awake()
    {
        text = GetComponent<Text>();
        buttomAdd = transform.GetChild(0).gameObject;
    }
    public virtual void setText(string text)
    {
        this.text.text = text;
    }
    public virtual void setActiveButtom(bool isActive)
    {
        buttomAdd.SetActive(isActive);
    }
   
}
