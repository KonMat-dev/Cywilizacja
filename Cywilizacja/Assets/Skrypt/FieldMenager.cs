using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMenager : MonoBehaviour
{
    public RowManager[] allRows;
    public HexBattale[,] allHexesArray;  // przechowuje wszystkie hexy na planszy 
    int allRowsLenght;

    // Start is called before the first frame update
    void Start()
    {
        allRows = GetComponentsInChildren<RowManager>();
        allRowsLenght = allRows.Length;
        for (int i = 0; i < allRowsLenght; i++) 
            {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<HexBattale>();
            }
        
        CreateAllHexesArray();

        CrateActiveHexesArray();

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
                allHexesArray[j, i] = allRows[ heightOfArray - i - 1].allHexesInRow[widthOfArray - j - 1];
                allHexesArray[j, i].verticalCoordinate = i+1;
                allHexesArray[j, i].horizonalCoordinate = j + 1;
                }
            }
        }

    private void CrateActiveHexesArray()
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

}
