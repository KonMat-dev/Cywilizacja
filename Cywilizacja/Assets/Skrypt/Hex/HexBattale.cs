using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };

public class HexBattale : MonoBehaviour
{
    public int horizonalCoordinate;
    public int verticalCoordinate;
    public Image Landscape;

    public HexState battaleState;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeMeActive() {
        battaleState = HexState.active;
    }

    public void MakeMeInactive() {
        if (battaleState != HexState.active) 
        {
            Landscape.color = new Color32(170, 170, 170, 255);
        }
    }
}
