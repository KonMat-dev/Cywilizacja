using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 5;
    public CharAttributes heroData;
    public BattaleControler battaleControler;
    public bool alreadyMoved;
    public Stack stack; // variable caching for a child object
    public bool alreadyAttacked;
    public bool alreadyMined;

    public abstract void DealsDamage(HexBattale target);

    private void Awake()
    {
        heroData.SetCurrentAttributes();//loads the current characteristics of the hero
        battaleControler = FindObjectOfType<BattaleControler>();
        alreadyAttacked = false;
        alreadyMined = false;
    }

    public void setAlreadyAttacked(bool i)
    {
        alreadyAttacked = i;
    }

    public void setAlreadyMined(bool i)
    {
        alreadyMined = i;
    }

    public void setAlreadyMoved(bool _alreadyMoved)
    {
        alreadyMoved = _alreadyMoved;
    }

    public bool getAlreadyMoved()
    {
        return alreadyMoved;
    }

    public virtual void refresh()
    {

    }

    void Start()
    {
        alreadyMoved = false;
        STorageMNG.OnClickOnGrayIcon += DestroyMe; //subscribes the DestroyMe method to an OnRemoveHero event
        stack = GetComponentInChildren<Stack>();
        if (heroData.ownerID == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        }
    }

    public void DestroyMe(CharAttributes SOHero)//destroys this object
    {
        if (SOHero == heroData)// compares the player’s choice with the hero
        {
            HexBattale parentHex = GetComponentInParent<HexBattale>();
            parentHex.MakeMeDeploymentPosition();
            Destroy(gameObject);
        }
    }

    public void ClearMe(CharAttributes SOHero)//destroys this object
    {
        if (SOHero == heroData)// compares the player’s choice with the hero
        {
            HexBattale parentHex = GetComponentInParent<HexBattale>();
            parentHex.potentialTarget = false;
            Destroy(gameObject);
        }
    }
    void OnDisable()//It is activated when the object is destroyed or disabled
    {
        STorageMNG.OnClickOnGrayIcon -= DestroyMe;//unsubscribes from notifications
    }

    public void setOwnerID(int _playerID)
    {
        heroData.setOwnerID(_playerID);
    }

    public void setHeroData(CharAttributes _heroData)
    {
        heroData = _heroData;
    }
    public abstract IAdjacentFinder GetTypeOfHero();//determines the type of movement

    public abstract void DefineTargets();
    public virtual void HeroIsAtacking() { } // start an attack
}
