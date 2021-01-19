﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroAttributes", menuName = "Fighter")]
public class CharAttributes : ScriptableObject
{
    public int velocity;
    public int hp;
    public int atack;
    public int resistance;
    public int stack;
    public int ownerID;

    public CharAttributes(
        int _velocity, int _hp, int _atack,
        int _resistance, int _stack, Sprite _heroSprite,
        Hero _heroSO, int _ownerID )
    {
        velocity = _velocity;
        hp = _hp;
        atack = _atack;
        resistance = _resistance;
        stack = _stack;
        heroSprite = _heroSprite;
        heroSO = _heroSO;
        ownerID = _ownerID;
    }

    public void setOwnerID(int _ownerID)
    {
        ownerID = _ownerID;
    }

    [SerializeField] int atackdistanse;

    [Header("General Attributes")]
    public bool isRanger;
    public bool isFlying;
    public Sprite heroSprite;
    public Hero heroSO;

    [Header("Current Attributes")]
    float initiativeCurrent;
    public float InitiativeCurrent
    {
        get { return initiativeCurrent; }
        set { initiativeCurrent = value; }
    }
    int hpCurrent;
    public int HPCurrent
    {
        get { return hpCurrent; }
        set { hpCurrent = value; }
    }
    int atackCurrent;
    public int AtackCurrent
    {
        get { return atackCurrent; }
        set { atackCurrent = value; }
    }
    int resistanceCurrent;
    public int ResistanceCurrent
    {
        get { return resistanceCurrent; }
        set { resistanceCurrent = value; }
    }
    int stackCurrent;
    public int StackCurrent
    {
        get { return stackCurrent; }
        set//excludes negative variable value
        {
            if (stackCurrent > 0) { stackCurrent = value; }
            else { stackCurrent = 0; }
        }
    }
    public int Atackdistanse
    {
        get//returns 1 for melee fighters, returns value of atackdistance for flying fighters
        {
            if (!isRanger) { return 1; }
            else { return atackdistanse; }
        }
        //cannot set another value
    }
    int velocityCurrent;
    public int CurrentVelocity
    {
        get { return velocityCurrent; }
        set { velocityCurrent = value; }
    }
    public void SetCurrentAttributes()//at the beginning of the battle sets the default values
    {
        hpCurrent = hp;
        atackCurrent = atack;
        resistanceCurrent = resistance;
        stackCurrent = stack;
        velocityCurrent = velocity;
    }

}