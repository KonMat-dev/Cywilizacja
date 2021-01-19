using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattaleControler battaleControler;

    private void Start()
    {
        battaleControler = GetComponent<BattaleControler>();
    }
    public void InitializeNewTurn()
    {
        battaleControler.DefineNewAtacker();//finds an attacking hero
        Hero currentAtacker = BattaleControler.currentAtacker;//gets local atacker (for parameters)
        IAdjacentFinder adjFinder = currentAtacker.GetTypeOfHero();//determines the type of movement
        int stepsLimit = currentAtacker.heroData.CurrentVelocity;//gets current velocity of the atacker

        //determines possible positions
        currentAtacker.GetComponent<AviablePosition>().GetAvailablePositions(GetStartingHex(),
                                                     stepsLimit, adjFinder);
    }
    public void RemoveNewTurn()
    {

    }
    //returns the hex on which the attacking hero stands
    private HexBattale GetStartingHex()
    {
        HexBattale startingHex = BattaleControler.currentAtacker.GetComponentInParent<HexBattale>();
        startingHex.DefineMeAsStartingHex(); //changes the properties of the starting hex
        return startingHex;
    }
}
