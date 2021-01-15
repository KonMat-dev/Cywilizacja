using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployer : MonoBehaviour
{
    public static CharIcon readyForDeploymentIcon;//stores information about the icon that the player clicked on
    void Start()
    {
        ActivatePositionsForRegiments();
    }
    //DeployRegiment method instantiates the hero on the battlefield
    public static void DeployRegiment(HexBattale parentObject)//hero appears on parentObject
    {
        Hero regiment = readyForDeploymentIcon.charAttributes.heroSO;// gets the hero prefab
        Hero fighter = Instantiate(regiment, parentObject.Landscape.transform);//instantiates the hero and
        //returns a hero object
        parentObject.CleanUpDeploymentPosition();//hides the checkmark and disables the collider
        readyForDeploymentIcon.HeroIsDeployed();//marks the icon in gray
        readyForDeploymentIcon = null;//clears a variable to prevent the hero from reappearing
    }
    void ActivatePositionsForRegiments() // displays the checkmark and enables the collider
    {
        foreach (HexBattale hex in FieldMenager.allHexesArray)
        {
            if (hex.deploymentPos.regimentPosition == PositionForRegiment.player)//if the variable of a hex is true then
                                                                                 //a hex is defined as a possible position
            {
                hex.MakeMeDeploymentPosition();//display the checkmark and enable the colliders
            }
        }
    }
}
