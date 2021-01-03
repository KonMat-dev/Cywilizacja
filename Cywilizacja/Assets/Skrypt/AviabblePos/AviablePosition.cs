using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviablePosition : MonoBehaviour
{
    private int step;
    List<HexBattale> initialHexes = new List<HexBattale>();
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
    internal List<HexBattale> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (HexBattale hex in FieldMenager.allHexesArray)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}