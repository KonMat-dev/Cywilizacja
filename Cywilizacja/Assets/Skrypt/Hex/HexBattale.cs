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
        distanceText.distanceFromStartingPoint = 0;
        isStrtingHex = true;
        distanceText.stepsToGo = 1;
    }

    public virtual bool AvailableToGround()
    {
        return true;
    }
    public void MakeMeDeploymentPosition()//displays the hex as a potential position for the hero
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = true;//enables collider (and clicking)
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 255);//displays a checkmark
    }
    public void CleanUpDeploymentPosition()//hides a checkmark, disables collider
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = false;// disables collider(and clicking)
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 0);//hides a checkmark
    }
    
    public void SetDefaultValue()
    {
        isStrtingHex = false;
        isNeighboringHex = false;
        distanceText.GetComponent<Text>().color = new Color32(255, 255, 255, 0);
        currentState.color = new Color32(255, 255, 255, 0);
        Landscape.color = new Color32(255, 255, 255, 255);
    }
}
