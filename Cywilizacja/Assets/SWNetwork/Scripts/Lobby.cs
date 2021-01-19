using UnityEngine;
using SWNetwork; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public enum LobbyState
    {
        Default,
        JoinedRoom,
    }

    public LobbyState State = LobbyState.Default;

    public Text Logo;
    public Button registerButton;
    public InputField nameField;

    public Text LookingForOpponent;
    public Button cancelButton;

    public string PlayerId;

    void Start()
    {
        NetworkClient.Lobby.OnRoomReadyEvent += Lobby_OnRoomReadyEvent;
        NetworkClient.Lobby.OnNewPlayerJoinRoomEvent += OnNewPlayerJoinRoomEvent;
        NetworkClient.Lobby.OnLobbyConnectedEvent += Lobby_OnLobbyConnectedEvent;
    }

    void OnDestroy()
    {
        // remove the handlers
        NetworkClient.Lobby.OnNewPlayerJoinRoomEvent -= OnNewPlayerJoinRoomEvent;
        NetworkClient.Lobby.OnRoomReadyEvent -= Lobby_OnRoomReadyEvent;
        NetworkClient.Lobby.OnFailedToStartRoomEvent -= Lobby_OnFailedToStartRoomEvent;
        NetworkClient.Lobby.OnLobbyConnectedEvent -= Lobby_OnLobbyConnectedEvent;
    }

    void OnNewPlayerJoinRoomEvent(SWJoinRoomEventData eventData)
    {
        if (NetworkClient.Lobby.IsOwner)
        {
            cancelButton.gameObject.SetActive(false);
            LookingForOpponent.gameObject.SetActive(false);
            StartRoom();
        }
    }

    /* Lobby events handlers */
    void Lobby_OnRoomReadyEvent(SWRoomReadyEventData eventData)
    {
        Debug.Log("Room is ready: roomId= " + eventData.roomId);
        ConnectToRoom();
    }

    void Lobby_OnFailedToStartRoomEvent(SWFailedToStartRoomEventData eventData)
    {
        Debug.Log("Failed to start room: " + eventData);
    }

    void Lobby_OnLobbyConnectedEvent()
    {
        Debug.Log("Lobby connected");
        RegisterPlayer();
    }

    /* UI event handlers */
    /// <summary>
    /// Register button was clicked
    /// </summary>
    public void Register()
    {
        PlayerId = nameField.text;
        Logo.gameObject.SetActive(false);
        registerButton.gameObject.SetActive(false);
        nameField.gameObject.SetActive(false);

        cancelButton.gameObject.SetActive(true);
        LookingForOpponent.gameObject.SetActive(true);

        if (PlayerId != null && PlayerId.Length > 0)
        {
            // use the user entered playerId to check into SocketWeaver. Make sure the PlayerId is unique.
            NetworkClient.Instance.CheckIn(PlayerId,(bool ok, string error) =>
            {
                if (!ok)
                {
                    Debug.LogError("Check-in failed: " + error);
                }
            });
        }
        else
        {
            // use a randomly generated playerId to check into SocketWeaver.
            NetworkClient.Instance.CheckIn((bool ok, string error) =>
            {
                if (!ok)
                {
                    Debug.LogError("Check-in failed: " + error);
                }
            });
        }
    }

    void Cancel()
    {
        NetworkClient.Lobby.LeaveRoom((successful, error) =>
        {
            if(successful)
            {
                Debug.Log("Left Room");
                State = LobbyState.Default;
                cancelButton.gameObject.SetActive(false);
                LookingForOpponent.gameObject.SetActive(false);

                Logo.gameObject.SetActive(true);
                registerButton.gameObject.SetActive(true);
                nameField.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Failed to leave room");
            }
        });
    }

    void RegisterPlayer()
    {
        NetworkClient.Lobby.Register(PlayerId,(successful, reply, error) =>
        {
            if (successful)
            {
                Debug.Log("Registered " + reply);

                if (string.IsNullOrEmpty(reply.roomId))
                {
                    NetworkClient.Lobby.JoinOrCreateRoom(false, 2, 0, HandleJoinOrCreatedRoom);
                }
                else if (reply.started)
                {
                    State = LobbyState.JoinedRoom;
                    ConnectToRoom();
                }
                else
                {
                    State = LobbyState.JoinedRoom;
                    LookingForOpponent.enabled = !LookingForOpponent.enabled;
                    cancelButton.enabled = !cancelButton.enabled;
                }
            }
            else
            {
                Debug.Log("Failed to register " + error);
            }
        });
    }

    void HandleJoinOrCreatedRoom(bool successful, SWJoinRoomReply reply, SWLobbyError error)
    {
        if (successful)
        {
            Debug.Log("Joined or created room " + reply);
            State = LobbyState.JoinedRoom;
            NetworkClient.Lobby.GetPlayersInRoom((s, r, er) => {
                if(r.players.Count == 2)
                {
                    LookingForOpponent.enabled = !LookingForOpponent.enabled;
                    cancelButton.enabled = !cancelButton.enabled;
                }
            });
        }
        else
        {
            Debug.Log("Failed to join or create room " + error);
        }
    }

    /// <summary>
    /// Start local player's current room. Lobby server will ask SocketWeaver to assign suitable game servers for the room.
    /// </summary>
    void StartRoom()
    {
        NetworkClient.Lobby.StartRoom((okay, error) =>
        {
            if (okay)
            {
                // Lobby server has sent request to SocketWeaver. The request is being processed.
                // If socketweaver finds suitable server, Lobby server will invoke the OnRoomReadyEvent.
                // If socketweaver cannot find suitable server, Lobby server will invoke the OnFailedToStartRoomEvent.
                Debug.Log("Started room");
            }
            else
            {
                Debug.Log("Failed to start room " + error);
            }
        });
    }

    /// <summary>
    /// Connect to the game servers of the room.
    /// </summary>
    void ConnectToRoom()
    {
        NetworkClient.Instance.ConnectToRoom(HandleConnectedToRoom);
    }

    void HandleConnectedToRoom(bool connected)
    {
        if (connected)
        {
            Debug.Log("Connected to room");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("Failed to connect to room");
        }
    }
}