using UnityEngine;
using UnityEngine.UI;

public enum PunchType { Speed = 0, Power = 1 }

public struct Card
{
    public string cardTitle; //Name of the card
    public int staminaCost; //Cost of stamina to play card
    public int damage; //Damge dealt if connect
    public int charges; //Amount of times a card can be used before it is destroyed
    public PunchType cardType; // Type of card
    public Sprite cardImage; //Image to be displayed on card

    public Card(string _title, int _cost, int _damage, int _charges, PunchType _type, Sprite _sprite)
    {
        cardTitle = _title;
        staminaCost = _cost;
        damage = _damage;
        charges = _charges;
        cardType = _type;
        cardImage = _sprite;
    }
}

public class UICard : MonoBehaviour {

    public Card cardInfo;

    // UI Variables
    public Image UIImage; //Image that exists in physical space
	public Text UITitle; //Text that exists in physical space
	public Text UICost; //^^

    public void Start()
    {
        UIImage.sprite = cardInfo.cardImage;
        UITitle.text = cardInfo.cardTitle;
        UICost.text = cardInfo.staminaCost.ToString();
    }
}
