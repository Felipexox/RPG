using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILifeBarPlayer : MonoBehaviour {
    [SerializeField]
    protected Slider uiSlider;

    protected virtual void Start()
    {
        uiSlider = GetComponent<Slider>();
    }

    public void setLifeValue(float value)
    {
        this.uiSlider.value = value;
    }
    public void setLifeMaxValue(float maxValue)
    {
        this.uiSlider.maxValue = maxValue;
    }
}
