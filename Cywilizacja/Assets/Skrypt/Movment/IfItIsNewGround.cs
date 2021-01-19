﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsNewGround : MonoBehaviour, IEvaluateHex
{
    public static IfItIsNewGround Instance;
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        return evaluatedHex.battaleState
                    == HexState.active
                    && !evaluatedHex.isStrtingHex
                    && !evaluatedHex.isIncluded
                    && evaluatedHex.AvailableToGround();
    }
}
