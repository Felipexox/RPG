using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoPlayerManager : MonoBehaviour {
    public static UIInfoPlayerManager instance;
    [SerializeField]
    protected UILevelPlayer uiLevelPlayer;

    [SerializeField]
    protected UIXPPlayer uiXPPlayer;

    [SerializeField]
    protected UINamePlayer uiNamePlayer;


    private void Awake()
    {
        instance = this;
        uiXPPlayer = GetComponentInChildren<UIXPPlayer>();
        uiLevelPlayer = GetComponentInChildren<UILevelPlayer>();
        uiNamePlayer = GetComponentInChildren<UINamePlayer>();
    }

    public void setLevelPlayer(int level)
    {
        uiLevelPlayer.setText(("LV: " + level));
    }

    public void setNamePlayer(string name)
    {
        uiNamePlayer.setText("Name: " + name);
    }

    public void setExperiencePlayer(float experience)
    {
        
        uiXPPlayer.setText("XP: " + (int) experience);
    }


}
