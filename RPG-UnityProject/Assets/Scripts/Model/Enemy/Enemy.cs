using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : Character {
    [SerializeField]
    private GameObject InfoObject;
    private Slider lifeBar;
    private Text nameUI;
    private void Start()
    {
        linkUI();
        setInformation();
    }
    private void Update()
    {
        lifeBar.value = status.getLife();
        died();
    }
    private void setInformation()
    {
        lifeBar.maxValue = status.getLife();
        nameUI.text = nameCharacter;
    }
    private void linkUI()
    {
        GameObject tempObj = Instantiate(InfoObject);
        tempObj.transform.parent = transform;
   
        tempObj.transform.localPosition = Vector3.zero;
        tempObj.GetComponent<RectTransform>().localPosition = new Vector3(0, 1, 0);
        lifeBar = tempObj.GetComponentInChildren<Slider>();
        nameUI = tempObj.GetComponentInChildren<Text>();
    }
    private void died()
    {
        if(status.getLife() <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
