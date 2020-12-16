using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattaleControler : MonoBehaviour
{
    FieldMenager fieldMenager = new FieldMenager();
    [SerializeField] int testInt;

    // Start is called before the first frame update
    void Start()
    {
        fieldMenager.RowHeight = 5;
        testInt = fieldMenager.RowHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
