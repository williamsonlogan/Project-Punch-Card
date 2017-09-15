using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Deck _playerDeck;
    public GameObject HandContainer;

	//Player Properties
	public Image UIImage;
	int stamina;
	int KOMeter;

	void Start () {
        if (HandContainer == null)
            HandContainer = GameObject.Find("OppHandContainer");

        loadDeckFromServer();
        dealHand();
	}

    /// <summary>
    /// Will connect to Photon server and load the deck the player chose
    /// </summary>
    private void loadDeckFromServer()
    {
        // Grab Deck from the server - Currently only grabs from local CSV
		_playerDeck = LoadCSV.Load(Resources.Load<TextAsset>("Data/testdeck"));
    }

    /// <summary>
    /// Draws 5 cards from the deck loaded from the server
    /// </summary>
    private void dealHand()
    {
        int deckSize = 5;
        for (int i = 0; i < deckSize && _playerDeck.Size > 0; ++i)
        {
            Card card = _playerDeck.Pop();
			GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/UICard"));
            go.GetComponent<UICard>().cardInfo = card;
            go.transform.SetParent(HandContainer.transform, false);
            go.GetComponent<Draggable>().enabled = true;
        }
    }
}
