using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattaleControler : MonoBehaviour
{
    public static HexBattale targetToMove;
    public static Hero currentAtacker;
    void Start()
    {
        currentAtacker = FindObjectOfType<Hero>();
    }


    void Update()
    {

    }
    private void Awake()
    {

    }
}
