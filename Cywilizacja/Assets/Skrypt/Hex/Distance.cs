using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int distanceFromStartingPoint;//counts distance from starting hex
    public int stepsToGo;//determines the number of steps to go through the hex
    HexBattale hex;
    Text distanceText; 

    private void Start()
    {
        hex = GetComponentInParent<HexBattale>();
        distanceText = GetComponent<Text>();
    }

    public void SetDistanceFromStartingHex(HexBattale initialHex)
    {
       
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint
                    + initialHex.distanceText.stepsToGo;

        distanceText.text = distanceFromStartingPoint.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }
    public bool EvaluateDistance(HexBattale initialHex)
    {
        return distanceFromStartingPoint + stepsToGo ==
                initialHex.distanceText.distanceFromStartingPoint;
    }
    public int MakeMePartOfOptimalPath()
    {
        OptimalPath.optimalPath.Add(hex);
        hex.Landscape.color = new Color32(150, 150, 150, 255);
        return stepsToGo;
    }

    public bool EvaluateDistanceForGround(HexBattale initialHex)
    {
        //distance to reach initial hex and get out of it
        int currentDistance = initialHex.distanceText.distanceFromStartingPoint
                              + initialHex.distanceText.stepsToGo;
        int stepsLimit = BattaleControler.currentAtacker.velocity;//velocity of a hero
        //default value of distanceFromStartingPoint is 20 to set the shortest path
        return distanceFromStartingPoint > currentDistance &&
                stepsLimit >= currentDistance;//to evaluate if the velocity is enough to reach this hex
    }
}
