using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public TextMeshProUGUI moneyTMP;
    public TextMeshProUGUI costTMP;

    public List<Player> players;
    public int numberOfPlayers;
    public int IDOfAnActivePlayer;

    private void Start()
    {
        Instance.IDOfAnActivePlayer = 0;
        Instance.numberOfPlayers = 2;
        Instance.players.Add(new Player(0));
        Instance.players.Add(new Player(1));
        updateUI();
    }

    public void ActivateNextPlayer()
    {
        BattaleControler bc = FindObjectOfType<BattaleControler>();
        OnClickCatle occ = bc.castles[bc.GetComponent<PlayerController>().IDOfAnActivePlayer].GetComponent<OnClickCatle>();
        HexBattale hex = occ.GetComponentInParent<HexBattale>();

        List<HexBattale> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(hex, new IfItIsNewGround());
        int x = 0;
        foreach (HexBattale hex2 in neighboursToCheck)
        {
            x++;
            DeploymentPos dpos = hex2.GetComponentInChildren<DeploymentPos>();
            dpos.setRegimentPositionToNone();
            Image image = dpos.GetComponent<Image>();
            image.color = new Color32(0, 0, 0, 0);
        }

        Instance.players[Instance.IDOfAnActivePlayer].addWealth(occ.lvl * 100);
        Instance.IDOfAnActivePlayer++;
        if (Instance.IDOfAnActivePlayer >= Instance.numberOfPlayers)
        {
            Instance.IDOfAnActivePlayer = 0;
            GetComponent<BattaleControler>().MakeFightersViableAgain();
        }

        occ = bc.castles[bc.GetComponent<PlayerController>().IDOfAnActivePlayer].GetComponent<OnClickCatle>();
        hex = occ.GetComponentInParent<HexBattale>();

        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(hex, new IfItIsNewGround());
        x = 0;
        foreach (HexBattale hex2 in neighboursToCheck)
        {
            x++;
            DeploymentPos dpos = hex2.GetComponentInChildren<DeploymentPos>();
            dpos.GetComponent<PolygonCollider2D>().enabled = true;
            dpos.setRegimentPositionToPlayer();
            Image image = dpos.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 255);
        }


        BattaleControler.currentTarget = null;
        BattaleControler.currentCastleTarget = null;
        updateUI();
    }

    public void UpgradeMyCastle()
    {
        BattaleControler bc = Instance.GetComponent<BattaleControler>();
        OnClickCatle occ = bc.castles[Instance.IDOfAnActivePlayer].GetComponent<OnClickCatle>();
        if(occ.cost <= wealthOfCurrentPlayer())
        {
            Instance.players[IDOfAnActivePlayer].addWealth(-occ.cost);
            occ.lvlup();
            updateUI();
        }
    }

    public void updateUI() 
    {
        Instance.moneyTMP.text = wealthOfCurrentPlayer().ToString();
        Instance.costTMP.text = costOfCurrentCastle().ToString();
    }

    public int costOfCurrentCastle()
    {
        BattaleControler bc = Instance.GetComponent<BattaleControler>();
        OnClickCatle occ = bc.castles[Instance.IDOfAnActivePlayer].GetComponent<OnClickCatle>();
        return occ.cost;
    }

    public int wealthOfCurrentPlayer()
    {
        return Instance.players[Instance.IDOfAnActivePlayer].wealth;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
}