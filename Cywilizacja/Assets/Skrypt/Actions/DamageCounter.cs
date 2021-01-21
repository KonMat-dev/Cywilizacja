using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    int totalDamage;//damage done by the entire attacking regiment
    int targetTotalHP; //the health of the entire attacked unit
    int targetStack;//number of units in the attacked regiment after the attack

    int DamageByUnit;
    public int TargetStack
    {
        get { return targetStack; }
        set//excludes negative variable value
        {
            if (value > 0) { targetStack = value; }
            else { targetStack = 0; }
        }
    }

    //calculates the number of units in an attacked regiment after the attack
    internal int CountTargetStack(Hero currentAtacker, Hero target)
    {
        totalDamage = CountDamageDealt(currentAtacker, target); //assigns the damage dealt to the variable

        //calculates the health of the entire regiment after the attack
        targetTotalHP = target.heroData.HPCurrent * target.heroData.StackCurrent - totalDamage;

        //calculates the number of units in an attacked regiment after the attack
        TargetStack = targetTotalHP / target.heroData.HPCurrent;
        return targetStack;
    }

    //calculates the damage done by the entire attacking regiment
    public int CountDamageDealt(Hero currentAtacker, Hero target)
    {
        //calculates the damage done by one unit
        DamageByUnit = currentAtacker.heroData.AtackCurrent - target.heroData.ResistanceCurrent;
        //calculates the damage done by the entire regiment
        int DamageByRegiment = DamageByUnit;
        return DamageByRegiment;
    }

}
