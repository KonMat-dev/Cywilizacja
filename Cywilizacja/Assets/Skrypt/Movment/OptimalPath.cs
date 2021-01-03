using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptimalPath : MonoBehaviour
{
    public static List<HexBattale> optimalPath = new List<HexBattale>();
    public static HexBattale nextStep;
    public List<Image> landscapes = new List<Image>();
    HexBattale targetHex;
    IAdjacentFinder AdjacentOption = new PosForPath();
    move move;
    private void Start()
    {
        move = GetComponent<move>();
    }
    
    internal void MatchPath()
    {
        optimalPath.Clear();
        targetHex = BattaleControler.targetToMove;
        optimalPath.Add(targetHex);

        //defines the distance from target hex
        int steps = targetHex.distanceText.distanceFromStartingPoint;
        for (int i = steps; i > 1;)
        {
            AdjacentOption.GetAdjacentHexesExtended(targetHex);
            targetHex = nextStep;
            i -= nextStep.distanceText.MakeMePartOfOptimalPath();
        }
        ManagePath();
    }
    void ManagePath()
    {
        landscapes.Clear();
        optimalPath.Reverse();
        foreach (HexBattale hex in optimalPath)
        {
            landscapes.Add(hex.Landscape);
        }
        move.path = landscapes;
    }
}
