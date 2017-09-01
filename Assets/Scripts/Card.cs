using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum PunchType { Speed = 0, Power = 1 }

public class Card : MonoBehaviour {

	public string cardTitle; //Name of the card
	public int staminaCost; //Cost of stamina to play card
	public int damage; //Damge dealt if connect
	public int charges; //Amount of times a card can be used before it is destroyed
	public PunchType cardType; // Type of card
	public Sprite cardImage; //Image to be displayed on card

    // UI Variables
    public Image UIImage; //Image that exists in physical space
	public Text UITitle; //Text that exists in physical space
	public Text UICost; //^^

    public void Start()
    {
        UIImage.sprite = cardImage;
        UITitle.text = cardTitle;
        UICost.text = staminaCost.ToString();
    }

    public Card(string _title, int _cost, int _damage, int _charges, PunchType _type, Sprite _sprite)
    {
        cardTitle = _title;
        staminaCost = _cost;
        damage = _damage;
        charges = _charges;
        cardType = _type;
        cardImage = _sprite;
    }

    public void Set(Card card)
    {
        cardTitle = card.cardTitle;
        staminaCost = card.staminaCost;
        damage = card.damage;
        charges = card.charges;
        cardType = card.cardType;
        cardImage = card.cardImage;
    }
}
