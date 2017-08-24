using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    // Static Members
    private static System.Random _rng;

    // Private Members
    private Stack<Card> _deck;

    // Public Members
    int Size { get { return _deck.Count; } }
    string Title;

    // Constructors
    Deck(string title, int size = 0)
    {
        Title = title;
        _deck = new Stack<Card>(size);
        _rng = new System.Random();
    }

    // Public Functions
    void Push(Card _card)
    {
        _deck.Push(_card);
    }

    Card Pop()
    {
        return _deck.Pop();
    }

    // Based off the Fisher-Yates shuffle
    void Shuffle()
    {
        List<Card> shuffled_deck = new List<Card>(_deck);
        _deck.Clear();

        int count = shuffled_deck.Count;
        while (count > 1)
        {
            --count;
            int rand_index = _rng.Next(count);

            Card swap = shuffled_deck[count];
            shuffled_deck[count] = shuffled_deck[rand_index];
            shuffled_deck[rand_index] = swap;
        }

        foreach (Card card in shuffled_deck)
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
