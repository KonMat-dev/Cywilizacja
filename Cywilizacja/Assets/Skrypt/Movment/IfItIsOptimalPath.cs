using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsOptimalPath : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        return evaluatedHex.isNeighboringHex;
    }
}
