using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };

public class HexBattale : MonoBehaviour
{
    public int horizonalCoordinate;
    public int verticalCoordinate;
    public Image Landscape;
    public bool isStrtingHex = false;
    [SerializeField] protected Image currentState;
    public bool isNeighboringHex = false;
    public bool isIncluded = false;
    public HexState battaleState;
    public ClickOnMe clickOnMe;
    public Distance distanceText;
    public DeploymentPos deploymentPos;

    private void Awake()
    {
        clickOnMe = GetComponent<ClickOnMe>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeMeActive() {
        battaleState = HexState.active;
    }

    public void MakeMeInactive() {
        if (battaleState != HexState.active) 
        {

            Landscape.color = new Color32(170, 170, 170, 255);
        }
    }

    public virtual void MakeMeAviable()
    {

        currentState.sprite = clickOnMe.fieldManager.availableToMove;
        currentState.color = new Color32(255, 255, 255, 255);
        
    }
    public virtual void MakeMeTargetToMove()
    {
        clickOnMe.isTargetToMove = true;
        BattaleControler.targetToMove = this;
        currentState.sprite = clickOnMe.fieldManager.availableAsTarget;

    }

    public void DefineMeAsStartingHex()
    {
        isStrtingHex = true;
        distanceText.stepsToGo = 1;
    }
}
