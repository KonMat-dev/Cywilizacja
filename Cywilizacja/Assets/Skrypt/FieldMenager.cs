using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMenager : MonoBehaviour
{
    public RowManager[] allRows;
   public static  HexBattale[,] allHexesArray;  // przechowuje wszystkie hexy na planszy 
    int allRowsLenght;
     public static List<HexBattale> activeHexList = new List<HexBattale>();

    public Sprite availableAsTarget; 
    public Sprite notAavailable; 
    public Sprite availableToMove; 


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
        CreateActiveHexList();
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
            if ((hex.transform.position.x > 15.2f || hex.transform.position.x < -25.2f) |
                Mathf.Abs(hex.transform.position.y) > 9.5f)
            {
                hex.MakeMeInactive();
            }
            else
            {
                hex.MakeMeActive();
            }
        }

    }

    
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
        HexBattale startingHex = hero.GetComponentInParent<HexBattale>();
        startingHex.DefineMeAsStartingHex();
        hero.GetAvailablePositions(hero.GetComponentInParent<HexBattale>(), 4, adjacentFinder);
    }
}
