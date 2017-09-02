using System.Collections.Generic;
using UnityEngine;

public class Deck {

    // Private Members
    private Stack<Card> _deck;
    private static System.Random _rng;

    // Public Members
    public int Size { get { return _deck.Count; } }
    public string Title;

    // Constructors
    public Deck(string title, int size = 0)
    {
        Title = title;
        _deck = new Stack<Card>(size);
        _rng = new System.Random();
    }

    // Public Functions
    public void Push(Card card)
    {
        _deck.Push(card);
    }

    public Card Pop()
    {
        return _deck.Pop();
    }

    // Based off the Fisher-Yates shuffle
    public void Shuffle()
    {
        List<Card> shuffledDeck = new List<Card>(_deck);
        _deck.Clear();

        int count = shuffledDeck.Count;
        while (count > 1)
        {
            --count;
            int randIndex = _rng.Next(count);

            Card swap = shuffledDeck[count];
            shuffledDeck[count] = shuffledDeck[randIndex];
            shuffledDeck[randIndex] = swap;
        }

        foreach (Card card in shuffledDeck)
            _deck.Push(card);
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
