using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    HexBattale hex;
    public bool isTargetToMove = false;
    public FieldMenager fieldManager;

    void Awake()
    {
        hex = GetComponent<HexBattale>();
        fieldManager = FindObjectOfType<FieldMenager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isTargetToMove)
            SelectTargetToMove();
        else 
        {
            BattaleControler.currentAtacker.GetComponent<move>().StartsMoving();
        }
    }

    private void SelectTargetToMove()
    {
        ClearPreviousSelectionOfTargetHex();


        if (hex.isNeighboringHex)
        {
            hex.MakeMeTargetToMove();
            BattaleControler.currentAtacker.GetComponent<OptimalPath>().MatchPath();
        }
    }

    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (HexBattale hex in FieldMenager.activeHexList)
        {
            if (hex.clickOnMe.isTargetToMove == true)
            {
                hex.GetComponent<ClickOnMe>().isTargetToMove = false;
                hex.MakeMeAviable();
            }
        }
    }
    }
