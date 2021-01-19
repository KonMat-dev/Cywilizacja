using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Stack : MonoBehaviour
{
    Hero parentHero;//refers to the parent Hero object
    private TextMeshProUGUI stackText; //refers to the TMPro component
    private int stack;//property to display the number of units
    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayInitialStack();//displays the initial number of units in a regiment
    }

    void DisplayInitialStack()//displays the initial number of units in a regiment
    {
        //takes the value of the initial number of units from the scriptable object
        stack = parentHero.heroData.stack;
        stackText.text = stack.ToString();//displays the number of units
    }
}

