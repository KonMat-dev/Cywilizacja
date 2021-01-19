using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero
{
    public override void DealsDamage(HexBattale target)
    {

    }

    public override IAdjacentFinder GetTypeOfHero()
    {
        PositionsForGround adjFinder = new PositionsForGround();
        return adjFinder;
    }

    

}
