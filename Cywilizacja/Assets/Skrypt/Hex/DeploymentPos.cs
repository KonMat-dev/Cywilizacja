using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionForRegiment { none, player, enemy };
public class DeploymentPos : MonoBehaviour
{
    public PositionForRegiment regimentPosition;//helps display potential position

    public void OnMouseDown()//is executed when the user has pressed the mouse button while over the Collider.
    {
        HexBattale parentHex = GetComponentInParent<HexBattale>();//finds the parent hex
        //checks if the player clicked on the hex and if it is a potencial position
        if (Deployer.readyForDeploymentIcon != null && regimentPosition == PositionForRegiment.player && !parentHex.GetComponentInChildren<Hero>())
        {
            Deployer.DeployRegiment(parentHex);//deploys a regiment
        }
    }

    public void setRegimentPositionToPlayer()
    {
        regimentPosition = PositionForRegiment.player;
    }

    public void setRegimentPositionToNone()
    {
        regimentPosition = PositionForRegiment.none;
    }
}
 