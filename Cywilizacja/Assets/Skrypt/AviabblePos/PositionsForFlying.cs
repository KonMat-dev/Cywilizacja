using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForFlying : MonoBehaviour, IAdjacentFinder
{
    public void GetAdjacentHexesExtended(HexBattale initialHex)
    {
        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex);
        foreach (HexBattale hex in neighboursToCheck)
        {
            hex.isNeighboringHex = true;//defines the hex as adjacent to evaluted initial hex
            print("I implement interface, Ground Regiments");
        }
    }
}
