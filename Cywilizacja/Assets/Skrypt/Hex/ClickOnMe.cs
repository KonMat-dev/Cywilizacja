using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    HexBattale hex;
    public bool isTargetHex = false;//becomes true when the hex is clicked
    public FieldMenager fieldManager;

    void Awake()
    {
        hex = GetComponent<HexBattale>();
        fieldManager = FindObjectOfType<FieldMenager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClearPreviousSelectionOfTargetHex();
        
        
        if (hex.isNeighboringHex)
        {
            hex.MakeMeTargetToMove();
        }
    }
    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (HexBattale hex in FieldMenager.activeHexList)
        {
            if (hex.clickOnMe.isTargetHex == true)
            {
                hex.GetComponent<ClickOnMe>().isTargetHex = false;
                hex.MakeMeAviable();
            }
        }
    }
    }
