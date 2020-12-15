using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    [SerializeField]
    [Range(2,12)]
    public float speed;

    private Vector3 targetPosition;
    private bool isMoving = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)) 
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            Move();
            if (isMoving == true)
            {
                Cursor.visible = false;

            }
            else
            {

                Cursor.visible = true;
            }
        }
    }

    void SetTargetPosition() 
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
            isMoving = true;
      
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition) 
        {
            isMoving = false;
        }
        
    }

}
