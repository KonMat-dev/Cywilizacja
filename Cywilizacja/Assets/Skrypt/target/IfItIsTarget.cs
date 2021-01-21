using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsTarget : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(HexBattale evaluatedHex)
    {
        return (evaluatedHex.GetComponentInChildren<Hero>() != null &&
            evaluatedHex.GetComponentInChildren<Hero>().heroData.ownerID !=
            PlayerController.Instance.IDOfAnActivePlayer) || 
            (evaluatedHex.GetComponent<OnClickCatle>() != null && 
            evaluatedHex.GetComponent<OnClickCatle>().ownerID != 
            PlayerController.Instance.IDOfAnActivePlayer) || 
            (evaluatedHex.GetComponentInChildren<Cave>());
    }
}
