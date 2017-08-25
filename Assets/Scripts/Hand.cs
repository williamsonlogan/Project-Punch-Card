using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    int MaxHandSize;
    int CurrentHandSize { get { return Cards.Count; } }

    List<Card> Cards;

    // Constructor
    Hand(int _maxHandSize)
    {
        MaxHandSize = _maxHandSize;
        Cards = new List<Card>(_maxHandSize + 1); // This is one larger than max so that there is room for discard to take place
    }

    /// <summary>
    /// Takes in the player's deck and draws the top card.
    /// If there is no space for the card in the hand then it will ask the player to choose a card to discard, otherwise the card is simply added to the deck.
    /// Note: The drawn card can be discarded
    /// </summary>
    /// <param name="_deck"></param>
    public void DrawCard(Deck deck)
    {
        Cards.Add(deck.Pop());

        if (CurrentHandSize > MaxHandSize)
        {
            // Must discard a card before adding a new one
            DiscardCard();
        }
    }

    /// <summary>
    /// Invoked when there are too many cards in the player's hand.
    /// </summary>
    private void DiscardCard()
    {
        // Somehow ask player to choose a card to discard
        // For the moment it just removes the oldest card
        Card removed = Cards[0];
        Cards.Remove(removed);
    }

    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */
}
