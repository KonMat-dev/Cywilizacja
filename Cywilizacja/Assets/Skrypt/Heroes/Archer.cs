using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero
{
    void Start()
    {
        if (heroData.ownerID == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 127, 127, 255);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color32(127, 127, 127, 255);
        }
    }
    public override void DealsDamage(HexBattale target)
    {
        IAttacking dealsDamage = new SimpleMeleeAttack();//simple attack behavior reference
        //launches damage methods
        if (BattaleControler.currentCastleTarget == null)
        {
            dealsDamage.HeroIsDealingDamage(this, BattaleControler.currentTarget);
        } else
        {
            dealsDamage.HeroIsDealingDamage(this, BattaleControler.currentCastleTarget);
        }
    }

    public override IAdjacentFinder GetTypeOfHero()
    {
        PositionsForGround adjFinder = new PositionsForGround();
        return adjFinder;
    }

    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetPlayerRange();
        wayToLookForTargets.DefineTargets(this);
    }
}
