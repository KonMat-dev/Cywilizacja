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
    static public List<HexBattale> GetAdjacentHexes(HexBattale startingHex, IEvaluateHex chcekHex) {

        allNeighbours.Clear();


        int initialX = startingHex.horizonalCoordinate - 1; 
        int initialY = startingHex.verticalCoordinate - 1;
        
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (  x + y !=0&& chcekHex.EvaluateHex(FieldMenager.allHexesArray[initialX + x, initialY + y])
                     && FieldMenager.allHexesArray[initialX + x, initialY + y].battaleState
                       == HexState.active)        
                {
                    allNeighbours.Add(FieldMenager.allHexesArray[initialX + x, initialY + y]);
                 
                }
            }
        }
        return allNeighbours;
    }

}
