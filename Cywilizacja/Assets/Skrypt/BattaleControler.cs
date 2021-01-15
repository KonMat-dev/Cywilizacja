using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattaleControler : MonoBehaviour
{
    public static HexBattale targetToMove;
    public static Hero currentAtacker;
    void Awake()
    {
        currentAtacker = FindObjectOfType<Hero>();
    }


    void Start()
    {

    }

}
