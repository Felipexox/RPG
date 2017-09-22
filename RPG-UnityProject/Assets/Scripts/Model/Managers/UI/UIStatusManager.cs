using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatusManager : InventoryManager {
    private static UIStatusManager instance;

    [SerializeField]
    protected UIStatusLife uiStatusLife;

    [SerializeField]
    protected UIStatusForce uiStatusForce;

    [SerializeField]
    protected UIStatusDefense uiStatusDefense;

    [SerializeField]
    protected UIStatusCharisma uiStatusCharisma;

    [SerializeField]
    protected UIStatusInteligence uiStatusInteligence;


    protected void Awake()
    {
        instance = this;
        uiStatusCharisma = GetComponentInChildren<UIStatusCharisma>();
        uiStatusDefense = GetComponentInChildren<UIStatusDefense>();
        uiStatusForce = GetComponentInChildren<UIStatusForce>();
        uiStatusLife = GetComponentInChildren<UIStatusLife>();
        uiStatusInteligence = GetComponentInChildren<UIStatusInteligence>();

    }

    public static UIStatusManager getInstance()
    {
        return instance;
    }


    public void setStatusLifeText(float maxLife)
    {
        this.uiStatusLife.setText("Life: " + maxLife);
    }

    public void setStatusForceText(float force)
    {
        this.uiStatusForce.setText("Force: " + force);
    }

    public void setStatusCharismaText(float charisma)
    {
        this.uiStatusCharisma.setText("Charisma: " + charisma);
    }

    public void setStatusDefenseText(float defense)
    {
        this.uiStatusDefense.setText("Defense: " + defense);
    }

    public void setStatusInteligenceText(float inteligence)
    {
        this.uiStatusInteligence.setText("Inteligence: " + inteligence);
    }

    public void addStatusIntelingece()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addInteligence(1);
        pointsManager(player.getStatus());
    }

    public void addStatusForce()
    {
        
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addForce(1);
        pointsManager(player.getStatus());
    }

    public void addStatusAgillity()
    {

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addAgility(1);
        pointsManager(player.getStatus());
    }

    public void addStatusCharisma()
    {

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addCharisma(1);
        pointsManager(player.getStatus());
    }

    public void addStatusDefense()
    {

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addDefense(1);
        pointsManager(player.getStatus());
    }

    public void addStatusLife()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.getStatus().addMaxLife(15);
        pointsManager(player.getStatus());
    }

    public void setActiveButtomAdd(bool isActive)
    {
        uiStatusInteligence.setActiveButtom(isActive);
        uiStatusForce.setActiveButtom(isActive);
        uiStatusDefense.setActiveButtom(isActive);
        uiStatusLife.setActiveButtom(isActive);
        uiStatusCharisma.setActiveButtom(isActive);
    }

    public void pointsManager(Status status)
    {
        if (status.getPointsToAdd() > 0)
            status.removePointsToAdd();

        setActiveButtomAdd(status.havePointsToAdd());
    }
    
    public void setAllTexts(float maxLife, float force, float charisma, float defense, float inteligence)
    {
        setStatusLifeText(maxLife);
        setStatusInteligenceText(inteligence);
        setStatusForceText(force);
        setStatusDefenseText(defense);
        setStatusCharismaText(charisma);
    }
}
