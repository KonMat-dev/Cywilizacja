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
        if (hex.potentialTarget) //pole oznaczone na czerwono
        {
            Debug.Log("A potential target has been clicked and its");
            BattaleControler.currentCastleTarget = GetComponentInChildren<OnClickCatle>();
            Cave target = GetComponentInChildren<Cave>();
            if (target)
            {
                if (BattaleControler.currentAtacker.alreadyMined != true)
                {
                    PlayerController pc = FindObjectOfType<BattaleControler>().GetComponent<PlayerController>();
                    pc.players[pc.IDOfAnActivePlayer].addWealth(100);
                    pc.updateUI();
                    BattaleControler.currentAtacker.setAlreadyMined(true);
                }
            }
            else if(BattaleControler.currentCastleTarget)
            {
                Debug.Log("...a castle");
            }
            if (BattaleControler.currentCastleTarget == null)
            {
                BattaleControler.currentTarget = GetComponentInChildren<Hero>();
                Debug.Log("...a hero");
            }
            if (BattaleControler.currentAtacker != null)
            {
                BattaleControler.currentAtacker.HeroIsAtacking();
            }
            return;
        }
        if (!isTargetToMove)
        {
            SelectTargetToMove();
        }
        else
        {
            BattaleControler.currentAtacker.GetComponent<move>().StartsMoving();
        }
    }

    private void SelectTargetToMove()
    {
        if (hex.isNeighboringHex && BattaleControler.currentAtacker.GetComponent<HexBattale>() != hex && !hex.GetComponentInChildren<Hero>())
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
                isTargetToMove = false;
                hex.MakeMeAviable();
            }
            hex.Landscape.color = new Color32(250, 250, 250, 250);
        }

    }
}
