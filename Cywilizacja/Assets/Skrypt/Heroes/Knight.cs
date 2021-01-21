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
        stack = GetComponentInChildren<Stack>();
        if (heroData.ownerID == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 127, 127, 255);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color32(127, 127, 255, 255);
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
        IDefineTarget wayToLookForTargets = new TargetPlayerMelee();
        wayToLookForTargets.DefineTargets(this);
    }

    public override void HeroIsAtacking()
    {
        if (BattaleControler.currentCastleTarget == null)
        {
            DealsDamage(BattaleControler.currentTarget.GetComponentInParent<HexBattale>());
        } else
        {
            DealsDamage(BattaleControler.currentCastleTarget.GetComponentInParent<HexBattale>());
        }
    }

    public override void refresh()
    {
        _hp = heroData.hp;
    }
}
