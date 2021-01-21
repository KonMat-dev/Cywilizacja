using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Stack : MonoBehaviour
{
    Hero parentHero;//refers to the parent Hero object
    private TextMeshProUGUI stackText; //refers to the TMPro component
    public int stack;//property to display the number of units
    [SerializeField] float iterationCntrl;//shows how often we will reduce the regiment
    int iterationVal;   //regiment reduction value per unit of time
    Turn turn;

    public int IterationVal
    {
        get { return iterationVal; }
        set//eliminates rounding to zero
        {
            if (value < 1) { iterationVal = 1; }
            else { iterationVal = value; }
        }
    }


    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayCurrentStack();//displays the initial number of units in a regiment
        turn = FindObjectOfType<Turn>();
        stack = parentHero.heroData.hp;
        stackText.text = stack.ToString();
    }

   public void DisplayCurrentStack()//displays the initial number of units in a regiment
    {
        //takes the value of the initial number of units from the scriptable object
        stack = parentHero.heroData.hp;
        Debug.Log("The stack has been refreshed!");
        stackText.text = stack.ToString();//displays the number of units
    }

    void CheckIfHeroIsKilled()
    {

        if (parentHero.heroData.StackCurrent == 0)
        {
            parentHero.GetComponent<Animator>().SetTrigger("IsDead");
        }
    }

}

