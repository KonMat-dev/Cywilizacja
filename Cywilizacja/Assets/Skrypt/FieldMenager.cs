using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMenager : MonoBehaviour
{
    public RowManager[] allRows;
   public static  HexBattale[,] allHexesArray;  // przechowuje wszystkie hexy na planszy 
    int allRowsLenght;
     public static List<HexBattale> activeHexList = new List<HexBattale>();

    public Sprite availableAsTarget; //green frame
    public Sprite notAavailable; //enemy, red frame
    public Sprite availableToMove; //white frame

    // Start is called before the first frame update
    void Awake()
    {
        allRows = GetComponentsInChildren<RowManager>();
        allRowsLenght = allRows.Length;
        for (int i = 0; i < allRowsLenght; i++)
        {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<HexBattale>();
        }
        CreateAllHexesArray();
        IdentifyHexes();
    }

    private void CreateAllHexesArray() 
        {
        int heightOfArray = allRows.Length;
        int widthOfArray = allRows[0].allHexesInRow.Length;
        allHexesArray = new HexBattale[widthOfArray, heightOfArray];

        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allHexesArray[j, i] = allRows[heightOfArray - i - 1].
                                      allHexesInRow[widthOfArray - j - 1];
                allHexesArray[j, i].verticalCoordinate = i + 1;
                allHexesArray[j, i].horizonalCoordinate = j + 1;

            }
        }
    }

    private void IdentifyHexes()
    {
        foreach (HexBattale hex in allHexesArray)
        {
            if (Mathf.Abs(hex.transform.position.x) > 15.3f |
                Mathf.Abs(hex.transform.position.y) > 5.2f)
            {
                hex.MakeMeInactive();
            }
            else
            {
                hex.MakeMeActive();
            }
        }

    }

    //create list filled with active hess
    private void CreateActiveHexList() 
        {
        foreach (HexBattale hex in allHexesArray)
        {
            if (hex.battaleState == HexState.active)
            {
                //adds an active hex to the list
                activeHexList.Add(hex);
            }
        }
    }

    private void Start()
    {
     

        IdentifyHexes();
        AviablePosition hero = FindObjectOfType<AviablePosition>();
        IAdjacentFinder adjacentFinder = new PositionsForFlying();
        

        hero.GetAvailablePositions(hero.GetComponentInParent<HexBattale>(), 2, adjacentFinder);
    }
}
