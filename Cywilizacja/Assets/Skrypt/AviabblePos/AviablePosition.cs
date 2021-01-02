using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviablePosition : MonoBehaviour
{
    private int step;//counts iterations
    List<HexBattale> initialHexes = new List<HexBattale>();//collects neighbouring hexes for evaluated hex
    public void GetAvailablePositions(HexBattale startingHex, int stepsLimit, IAdjacentFinder AdjFinder)
    {

        AdjFinder.GetAdjacentHexesExtended(startingHex);
        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = GetNewInitialHexes();
            foreach (HexBattale hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }
    internal List<HexBattale> GetNewInitialHexes()//collects objects whose neighbours need to be found
    {
        initialHexes.Clear();// empty the array before filling it again
        foreach (HexBattale hex in FieldMenager.allHexesArray)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)//eliminates unnecessary hexes
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}