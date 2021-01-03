using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosForPath : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsOptimalPath();
    public void GetAdjacentHexesExtended(HexBattale initialHex)
    {

        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (HexBattale hex in neighboursToCheck)
        {
            //compare distances between two hexes
            if (hex.distanceText.EvaluateDistance(initialHex))
            {
                OptimalPath.nextStep = hex;
                break;
            }
        }
    }
}
