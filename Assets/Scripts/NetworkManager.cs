using UnityEngine;

public class NetworkManager : MonoBehaviour
{
	PunTurnManager TurnManager;
    GameObject oppHandContainer;
    GameObject oppLeftContainer;
    GameObject oppRightContainer;

    // Use this for initialization
    void Start() {
        // Start scene for selecting Champ/Deck and retrieve that information
        
        // Pass Info from GUI selection to connect - later these selections will be passed to SpawnPlayer so that they have dekc /hand dealing info
		TurnManager = this.GetComponent<PunTurnManager>();
        oppHandContainer = GameObject.FindWithTag("OppHand");
        oppLeftContainer = GameObject.Find("OppLeft");
        oppRightContainer = GameObject.Find("OppRight");

        Connect();
    }

    void Connect() {
        PhotonNetwork.ConnectUsingSettings("testver");
    }

    void OnGUI() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Lobby Joined");
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Creating Room");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Room Joined");

        // Spawns player locally
        SpawnMyPlayer();
        TurnManager.BeginTurn();
    }

    /// <summary>
    /// Spawns the local client's player object
    /// </summary>
    void SpawnMyPlayer()
    {
        GameObject playerGO = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
        playerGO.tag = "Local Player";
        Player player = playerGO.GetComponent<Player>();
        player.HandContainer = GameObject.Find("HandContainer");
    }
}
