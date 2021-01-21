using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerRange : MonoBehaviour, IDefineTarget
{
    HexBattale initialHex;
    List<HexBattale> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();

    public void DefineTargets(Hero currentAttacker)
    {
        initialHex = currentAttacker.GetComponentInParent<HexBattale>();
        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach(HexBattale hex in neighboursToCheck)
        {
            hex.DefineMeAsPotentialHex();
        }
    }
}
