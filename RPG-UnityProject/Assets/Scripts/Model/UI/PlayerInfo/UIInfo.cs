using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInfo : MonoBehaviour {
    [SerializeField]
    protected Text uiText;

    protected virtual void Start()
    {
        uiText = GetComponent<Text>();
    }

    public virtual void setText(string text)
    {
        this.uiText.text = text;
    }

}
