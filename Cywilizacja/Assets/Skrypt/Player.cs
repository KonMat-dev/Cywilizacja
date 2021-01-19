using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ID;
    public int wealth;

    public Player(int _ID)
    {
        wealth = 100;
    }

    public void addWealth(int _wealth)
    {
        wealth += _wealth;
    }
}