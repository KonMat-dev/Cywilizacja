using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHero : MonoBehaviour
{
    public Hero hero;
    public bool alreadyMoved;
    int ID;

    private void Start()
    {
        hero = GetComponent<Hero>();
        alreadyMoved = hero.getAlreadyMoved();
        ID = hero.heroData.ownerID;
    }
    void OnMouseDown()
    {
        BattaleControler battaleControler = hero.battaleControler;
        if (ID == PlayerController.Instance.IDOfAnActivePlayer) {
            if (alreadyMoved == false)
            {
                battaleControler.GetComponent<Turn>().InitializeNewTurn(hero);
                alreadyMoved = true;
            }
        }
/*      if (alreadyMoved == true)
        {
            battaleControler.GetComponent<Turn>().InitializeNewTurn();
            alreadyMoved = false;
        }*/
    }

    public void makeFighterViableAgain()
    {
        alreadyMoved = false;
    }
}
