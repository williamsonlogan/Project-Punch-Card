using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Deck PlayerDeck;
    Hand PlayerHand;

	/// <summary>
    /// The player start
    /// </summary>
	void Start () {
        loadDeckFromServer();
        dealHand();
	}

    /// <summary>
    /// Will connect to Photon server and load the deck the player chose
    /// </summary>
    private void loadDeckFromServer()
    {
        // Grab Deck from the server - Currently only grabs from local CSV
        PlayerDeck = LoadCSV.Load("testdeck");
    }

    /// <summary>
    /// Draws 5 cards from the deck loaded from the server
    /// </summary>
    private void dealHand()
    {
        for (int i = 0; i < 5 && PlayerDeck.Size > 0; ++i)
            PlayerHand.DrawCard(PlayerDeck);
    }
}
