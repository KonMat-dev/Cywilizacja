using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woda : HexBattale
{
    public override void MakeMeTargetToMove()
    {

         clickOnMe.ClearPreviousSelectionOfTargetHex();

    }
    public override void MakeMeAviable()
    {
        currentState.color = new Color32(255, 255, 255, 0);
    }
}
