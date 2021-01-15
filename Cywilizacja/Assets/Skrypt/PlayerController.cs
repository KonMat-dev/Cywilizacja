using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public List<Player> players;
    public int numberOfPlayers;
    public int IDOfAnActivePlayer;

    private void Start()
    {
        Instance.IDOfAnActivePlayer = 0;
        Instance.numberOfPlayers = 2;
        Instance.players.Add(new Player(0));
        Instance.players.Add(new Player(1));
    }

    public void ActivateNextPlayer()
    {
        Instance.players[Instance.IDOfAnActivePlayer].addWealth(100);
        Debug.Log("players[ " + Instance.IDOfAnActivePlayer + " ].wealth = " + Instance.players[Instance.IDOfAnActivePlayer].wealth);
        Instance.IDOfAnActivePlayer++;
        if(Instance.IDOfAnActivePlayer >= Instance.numberOfPlayers)
        {
            Instance.IDOfAnActivePlayer = 0;
        }
        Debug.Log("Id of an active player = " + Instance.IDOfAnActivePlayer);
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
