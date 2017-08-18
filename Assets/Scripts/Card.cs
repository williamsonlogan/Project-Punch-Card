using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PunchType { Speed = 0, Power = 1 }

public class Card : MonoBehaviour {
	public string cardTitle; //Name of the card
	public int staminaCost = 1; //Cost of stamina to play card
	public int damage = 1; //Damge dealt if connect
	public PunchType cardType; // Type of card
	public Image cardImage; //Image to be displayed on card

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
