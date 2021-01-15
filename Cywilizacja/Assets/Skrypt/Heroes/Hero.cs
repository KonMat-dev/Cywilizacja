using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 5;
    public CharAttributes heroData;

    public abstract void DealsDamage(HexBattale target);


    private void Start()
    {
        STorageMNG.OnClickOnGrayIcon += DestroyMe; //subscribes the DestroyMe method to an OnRemoveHero event
    }

    private void DestroyMe(CharAttributes SOHero)//destroys this object
    {
        if (SOHero == heroData)// compares the player’s choice with the hero
        {
            HexBattale parentHex = GetComponentInParent<HexBattale>();
            parentHex.MakeMeDeploymentPosition();
            Destroy(gameObject);
        }
    }
    void OnDisable()//It is activated when the object is destroyed or disabled
    {
        STorageMNG.OnClickOnGrayIcon -= DestroyMe;//unsubscribes from notifications
    }
}

