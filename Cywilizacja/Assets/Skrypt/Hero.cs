using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int velocity = 4 ;
    public int health = 50;

    public int Health
    {
        get => health;
        private set { health = value; }
    }


        void Start()
    {
        print(health);
        health = 34;
        print(health);

    }
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

}

