using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeAttack : MonoBehaviour , IAttacking
{
    DamageCounter damageController = new DamageCounter();//access to damage calculation
    int damage;//final numbers after the attack
    public void HeroIsDealingDamage(Hero atacker, Hero Target)
    {
        if (!atacker.alreadyAttacked) {
            if (atacker != Target) {
                //calculates the final number of units in the regiment of the attacked hero
                damage = damageController.CountDamageDealt(atacker, Target);
                BattaleControler battaleControler = FindObjectOfType<BattaleControler>();
                int currentInt = Target.heroData.StackCurrent;
                //assigns a new value to the number of units of the attacked hero
                HexBattale hex = atacker.GetComponentInParent<HexBattale>();
                float multipier = 1.0f;
                if(hex.GetComponentInChildren<Forest>())
                {
                    multipier = 0.5f;
                }
                Target.heroData.changeHP((int)(-damage * multipier));
                Target.stack.DisplayCurrentStack();
                atacker.alreadyAttacked = true;
                if (Target.heroData.hp <= 0)
                {
                    Target.ClearMe(Target.heroData);
                }
                battaleControler.CleanField();
            }
        }
        //Target.stack.StartCoroutine(Target.stack.CountDownToTargetStack(currentInt, targetStack));
    }

    public void HeroIsDealingDamage(Hero atacker, OnClickCatle Target)
    {
        if (!atacker.alreadyAttacked)
        {
            if (atacker != Target)
            {
                //calculates the final number of units in the regiment of the attacked hero
                damage = atacker.heroData.atack;
                BattaleControler battaleControler = FindObjectOfType<BattaleControler>();
                //assigns a new value to the number of units of the attacked hero
                HexBattale hex = atacker.GetComponentInParent<HexBattale>();
                float multipier = 1.0f;
                if (hex.GetComponentInChildren<Forest>())
                {
                    multipier = 0.5f;
                }
                Target.takeDamage((int)(damage * multipier));
                atacker.alreadyAttacked = true;
                if (Target.hp <= 0)
                {
                    Target.ClearMe();
                }
                battaleControler.CleanField();
            }
        }
        //Target.stack.StartCoroutine(Target.stack.CountDownToTargetStack(currentInt, targetStack));
    }
}
