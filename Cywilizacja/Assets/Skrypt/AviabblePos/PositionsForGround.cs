using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForGround : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex chcekHex = new IfItsNewHex();
    public void GetAdjacentHexesExtended(HexBattale initialHex)
    {
        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, chcekHex);
        foreach (HexBattale hex in neighboursToCheck)
        {
            hex.isNeighboringHex = true;
            hex.distanceText.SetDistanceFromStartingHex(initialHex);
            hex.MakeMeAviable();
        }
    }
}
