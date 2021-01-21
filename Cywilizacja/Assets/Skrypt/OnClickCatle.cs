using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OnClickCatle : MonoBehaviour
{
    [SerializeField]
    
    GameObject Panel;
    public int ownerID;
    public int hp;
    public int lvl;
    public int cost;
    public TextMeshProUGUI tmpHP;
    GameObject obj;

    public void Start()
    {
        Panel.SetActive(false);
        hp = 250;
        lvl = 1;
        cost = 100;
        BattaleControler bc = FindObjectOfType<BattaleControler>();
        PlayerController pc = bc.GetComponent<PlayerController>();
        tmpHP = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        pc.updateUI();
        refreshText();
    }

    public void refreshText()
    {
        tmpHP.text = hp.ToString();
    }

    void OnMouseDown()
    {
        if (ownerID == PlayerController.Instance.IDOfAnActivePlayer)
        {
            if (gameObject.name.Equals("Castle1"))
            {
                Panel.SetActive(true);
            }
        }
        if (gameObject.name.Equals("Close"))
        {
            Panel.SetActive(false);
        }
    }

    public void lvlup()
    {
        lvl += 1;
        hp += + lvl * lvl * 10;
        cost += lvl * lvl * lvl * 5;
        refreshText();
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        refreshText();
    }

    public void ClearMe() //destroys this object
    {
        HexBattale parentHex = GetComponentInParent<HexBattale>();
        parentHex.potentialTarget = false;
        if (PlayerController.Instance.IDOfAnActivePlayer == 0) {
            SceneManager.LoadScene("WinPlayer1");
        } else {
            SceneManager.LoadScene("WinPlayer2");
        }
        Destroy(gameObject);
        
        
    }

    public int getLvl()
    {
        return lvl;
    }
}
