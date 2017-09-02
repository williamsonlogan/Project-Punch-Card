using UnityEngine;

public class Player : MonoBehaviour {

    Deck PlayerDeck;
    GameObject _handContainer;
    public bool IsOppPlayer;

	/// <summary>
    /// The player start
    /// </summary>
	void Start () {
        if (!IsOppPlayer)
            _handContainer = GameObject.Find("HandContainer");
        else
            _handContainer = GameObject.Find("OppHandContainer");

        loadDeckFromServer();
        dealHand();
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

			if(_handContainer == GameObject.Find("OppHandContainer"))
			{
				go.GetComponent<Draggable> ().enabled = false;
			}
        }
    }
}
