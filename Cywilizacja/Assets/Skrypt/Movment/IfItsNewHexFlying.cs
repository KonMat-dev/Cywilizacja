using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItsNewHexFlying : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        return evaluatedHex.battaleState
                   == HexState.active
                   && !evaluatedHex.isStrtingHex
                   && !evaluatedHex.isNeighboringHex;
    }
}
