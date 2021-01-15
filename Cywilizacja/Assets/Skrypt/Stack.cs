using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Stack : MonoBehaviour
{
    Hero parentHero;//refers to the parent Hero object
    private TextMeshProUGUI stackText; //refers to the TMPro component
    private int _stack;//property to display the number of units
    internal int currentStack
    {
        get { return _stack; }
        set
        {
            if (value > 0) { _stack = value; }//excludes negative values
            else { _stack = 0; }
        }
    }
    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayInitialStack();//displays the initial number of units in a regiment
    }

    void DisplayInitialStack()//displays the initial number of units in a regiment
    {
        //takes the value of the initial number of units from the scriptable object
        currentStack = parentHero.heroData.stack;

        stackText.text = currentStack.ToString();//displays the number of units
    }
}

