using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCatle : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;
    public int ownerID;

    public void Start()
    {
        Panel.SetActive(false);
    }

    void OnMouseDown()
    {
        Debug.Log(ownerID + " == " + PlayerController.Instance.IDOfAnActivePlayer);
        if (ownerID == PlayerController.Instance.IDOfAnActivePlayer)
        {
            if (gameObject.name.Equals("Castle1"))
            {
                Panel.SetActive(true);
            }
            else if (gameObject.name.Equals("Close"))
            {
                Panel.SetActive(false);
            }
        }
    }
}
