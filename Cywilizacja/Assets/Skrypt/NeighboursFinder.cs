using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursFinder : MonoBehaviour
{
    static private HexBattale startingHex;
    static List<HexBattale> allNeighbours = new List<HexBattale>();
    private FieldMenager sceneManager;

    // Start is called before the first frame update
    void Start()
    {

    }
    static public List<HexBattale> GetAdjacentHexes(HexBattale startingHex) { 
        int initialX = startingHex.horizonalCoordinate - 1; //first index for two-dimensional list
        int initialY = startingHex.verticalCoordinate - 1;//second index for two-dimensional list
        //iterates x and y from -1 to 1 to get adjacent hexes referring to the coordinates of starting hex
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (  x + y !=0&& //exclude two hexes that are not adjacent hexes
                     EvaluateIfItIsNewHex(FieldMenager.allHexesArray[initialX + x, initialY + y])
                     && FieldMenager.allHexesArray[initialX + x, initialY + y].battaleState
                       == HexState.active) //exclude inactive hexes                       
                {
                    allNeighbours.Add(FieldMenager.allHexesArray[initialX + x, initialY + y]);
                    FieldMenager.allHexesArray[initialX + x, initialY + y].MakeMeAviable();
                }
            }
        }
        return allNeighbours;
    }
    //evaluates the state of a hex (active, included and neighbouring)
    private static bool EvaluateIfItIsNewHex(HexBattale evaluatedHex)
    {
        return evaluatedHex.battaleState
                            == HexState.active
                            && !evaluatedHex.isIncluded
                            && !evaluatedHex.isNeighboringHex;
    }
}
