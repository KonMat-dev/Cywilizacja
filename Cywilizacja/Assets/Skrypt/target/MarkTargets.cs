using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTargets : IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsTargetRange();// to access the behavior we need 
    public void GetAdjacentHexesExtended(HexBattale initialHex)
    {
        //collect hexes that meet the criteria defined by the IfItIsTargetRange rule
        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);

        int i = 0;
        foreach (HexBattale hex in neighboursToCheck)
        {
            hex.lookingForTarget = true;//defines the hex as adjacent to evaluted  hex
            if (hex.GetComponentInChildren<Hero>() != null && hex.GetComponentInChildren<OnClickCatle>() != null && hex.GetComponentInChildren<Cave>() != null)
            {
                i++;
                hex.DefineMeAsPotentialHex();//marks hex as a potential target
            }
        }
    }
}