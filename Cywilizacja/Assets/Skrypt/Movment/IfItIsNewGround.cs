using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsNewGround : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        bool x = evaluatedHex.battaleState
                    == HexState.active
                    && !evaluatedHex.isStrtingHex
                    && !evaluatedHex.isIncluded;
        bool y = evaluatedHex.battaleState
                    == HexState.active;

        return x;
    }
}
