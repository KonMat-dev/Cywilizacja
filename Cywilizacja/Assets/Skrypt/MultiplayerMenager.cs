using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWNetwork;
using Assets.Skrypt;

public class MultiplayerMenager : MonoBehaviour
{
    public RemoteEventAgent remoteEventAgent;

    private void Start()
    {
        remoteEventAgent = gameObject.GetComponent<RemoteEventAgent>();
    }

    public void sendMessage(GameState gameState)
    {
        SWNetworkMessage message = new SWNetworkMessage();
        message.Push(gameState.gold1);
        message.Push(gameState.cityLvl1);
        message.Push(gameState.cityCurrentHP1);
        message.Push(gameState.cityMaxHP1);

        message.Push(gameState.gold2);
        message.Push(gameState.cityLvl2);
        message.Push(gameState.cityCurrentHP2);
        message.Push(gameState.cityMaxHP2);

        this.remoteEventAgent.Invoke("ChangedGameState", message);
    }

    public void applyChanges(GameState gameState, SWNetworkMessage message)
    {
        gameState.gold1 = message.PopByte();
        gameState.cityLvl1 = message.PopByte();
        gameState.cityCurrentHP1 = message.PopByte();
        gameState.cityMaxHP1 = message.PopByte();

        gameState.gold2 = message.PopByte();
        gameState.cityLvl2 = message.PopByte();
        gameState.cityCurrentHP2 = message.PopByte();
        gameState.cityMaxHP2 = message.PopByte();
    }
}
