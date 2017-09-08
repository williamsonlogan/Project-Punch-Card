using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    // UI Variables
    public Text StaminaText;

    Deck PlayerDeck;
    GameObject _handContainer;

	//Player Properties
	public Image UIImage;
	int stamina;
	int KOMeter;

	/// <summary>
    /// The player start
    /// </summary>
	void Start () {
        if (isLocalPlayer)
            _handContainer = GameObject.FindGameObjectWithTag("HandContainer");
        else
            _handContainer = GameObject.FindGameObjectWithTag("OppHandContainer");

        loadDeckFromServer();
        dealHand();
	}

    public override void OnStartLocalPlayer()
    {
        this.transform.SetParent(GameObject.Find)
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
    private void dealHand()
    {
        for (int i = 0; i < 5 && PlayerDeck.Size > 0; ++i)
        {
            Card card = PlayerDeck.Pop();
			GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/UICard"));
            go.GetComponent<UICard>().cardInfo = card;
            go.transform.SetParent(_handContainer.transform, false);

			if(!isLocalPlayer)
				go.GetComponent<Draggable> ().enabled = false;
        }
    }
}
