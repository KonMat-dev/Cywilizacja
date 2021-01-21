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
        int num1, num2, cost;

            BattaleControler bc = FindObjectOfType<BattaleControler>();

            if (readyForDeploymentIcon.charAttributes.heroSprite == bc.warrior) {
                num1 = 100;
                num2 = 25;
                cost = 100;
            } else if (readyForDeploymentIcon.charAttributes.heroSprite == bc.ranger) {
                num1 = 75;
                num2 = 35;
                cost = 150;
            } else {
                num1 = 125;
                num2 = 50;
                cost = 350;    
            }

            regiment.setHeroData(new CharAttributes(0, num1, num2, 0, 0, readyForDeploymentIcon.charAttributes.heroSprite, readyForDeploymentIcon.charAttributes.heroSO, 0));
            regiment.setOwnerID(PlayerController.Instance.IDOfAnActivePlayer);
        //GameObject hero =
        PlayerController pc = bc.GetComponent<PlayerController>();
        if (cost <= pc.players[pc.IDOfAnActivePlayer].wealth) {
            pc.players[pc.IDOfAnActivePlayer].addWealth(-cost);
            pc.updateUI();
            Instantiate(regiment, parentObject.Landscape.transform);//instantiates the hero and
                                                                    //returns a hero object
                                                                    //hero.AddComponent<BoxCollider>(); tu coś pisałeś makaron 
            parentObject.CleanUpDeploymentPosition();//hides the checkmark and disables the collider
            readyForDeploymentIcon.HeroIsDeployed();//marks the icon in gray
            readyForDeploymentIcon = null;//clears a variable to prevent the hero from reappearing
        }

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
