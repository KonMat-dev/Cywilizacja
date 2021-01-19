﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattaleControler : MonoBehaviour
{
    public static HexBattale targetToMove;
    public static Hero currentAtacker;
    List<Hero> allFighters = new List<Hero>(); //collects all fighters placed on the battlefield

    //collects all fighters placed on the battlefield
    public List<Hero> DefineAllFighters()
    {
        allFighters = FindObjectsOfType<Hero>().ToList();
        return allFighters;
    }
    public void DefineNewAtacker()
    {
        //   sorts fighters by initiative value, in descending order
        List<Hero> allFighters = DefineAllFighters().
                                 OrderByDescending(hero => hero.heroData.InitiativeCurrent).ToList();
        //  the first element of the list has the biggest initiative value
        currentAtacker = allFighters[0];
    }

    public void CleanField()
    {
        foreach(HexBattale hex in FieldMenager.activeHexList)
        {
            hex.SetDefaultValue();
        }
    }

    public void MakeFightersViableAgain()
    {
        List<Hero> allFighters = DefineAllFighters().ToList();
        foreach(Hero fighter in allFighters)
        {
            fighter.setAlreadyMoved(false);
            fighter.GetComponent<OnClickHero>().makeFighterViableAgain();
        }
    }

}
