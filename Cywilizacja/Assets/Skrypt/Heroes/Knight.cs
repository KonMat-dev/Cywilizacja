using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Hero
{
    public int _velocity;
    public int _hp;
    public int _atack;
    public int _resistance;
    public int _stack;
    public Sprite _heroSprite;
    public Hero _heroSO;
    public int _ownerID;
    public bool _alreadyMoved = false;

    private void Start()
    {
        _velocity = heroData.velocity;
        _hp = heroData.hp;
        _atack = heroData.atack;
        _resistance = heroData.resistance;
        _stack = heroData.stack;
        _heroSprite = heroData.heroSprite;
        _heroSO = heroData.heroSO;
        _ownerID = heroData.ownerID;
        _alreadyMoved = false;
}
    public override void DealsDamage(HexBattale target)
    {

    }
    public override IAdjacentFinder GetTypeOfHero()
    {
        PositionsForGround adjFinder = new PositionsForGround();
        return adjFinder;
    }

    
}
