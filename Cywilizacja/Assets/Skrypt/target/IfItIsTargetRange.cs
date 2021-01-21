using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsTargetRange : IEvaluateHex
{
    // Start is called before the first frame update
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        return evaluatedHex.battaleState
                   == HexState.active//exclude inactive hexes 
                   && !evaluatedHex.isStrtingHex//exclude starting hex 
                   && !evaluatedHex.isStrtingHex;//exclude previously checked hex

    }
}
