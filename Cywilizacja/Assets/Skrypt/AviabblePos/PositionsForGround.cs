using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForGround : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex chcekHex = new IfItIsNewGround();
    public void GetAdjacentHexesExtended(HexBattale initialHex)
    {
        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, chcekHex);
        foreach (HexBattale hex in neighboursToCheck)
        {
            if (hex.distanceText.EvaluateDistanceForGround(initialHex)) {
                hex.isNeighboringHex = true;
                hex.distanceText.SetDistanceFromStartingHex(initialHex);
                hex.MakeMeAviable();
            }
        }
    }
}
