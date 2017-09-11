using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    // UI Variables
    public Text StaminaText;
    public GameObject HandContainer;

    Deck PlayerDeck;

	//Player Properties
	public Image UIImage;
	int stamina;
	int KOMeter;

    // Prefabs
    public GameObject CardSpawnerPrefab;

	void Start ()
    {
        this.transform.SetParent(GameObject.Find("Canvas").transform);
        loadDeckFromServer();
        dealHand(Vector3.zero);
    }

    public override void OnStartLocalPlayer()
    {
    }

    /// <summary>
    /// Will connect to Photon server and load the deck the player chose
    /// </summary>
    private void loadDeckFromServer()
    {
        // Grab Deck from the server - Currently only grabs from local CSV
		PlayerDeck = LoadCSV.Load(Resources.Load<TextAsset>("Data/testdeck"));
    }

    /// <summary>
    /// Draws 5 cards from the deck loaded from the server
    /// </summary>
    private void dealHand(Vector3 offset)
    {
        CardSpawner cardSpawner = CardSpawnerPrefab.GetComponent<CardSpawner>();
        for (int i = 0; i < 5 && PlayerDeck.Size > 0; ++i)
        {
            cardSpawner.SpawnCard(PlayerDeck.Pop(), HandContainer.transform, isLocalPlayer);
        }
    }
}
