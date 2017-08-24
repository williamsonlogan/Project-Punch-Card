using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadCSV : MonoBehaviour {
	Card Load(string file)
	{
		Card returnCard = new Card ();
		string loadedString;
		StreamReader sr = new StreamReader (file);
		loadedString = sr.ReadLine ();

		string[] split = loadedString.Split (",");

		for(int i = 0; i < split.GetLength(); i++){
			switch(i)
			{
			case 0:
				returnCard.cardTitle = split [i];
				break;
			case 1:
				returnCard.staminaCost = split [i];
				break;
			case 2:
				returnCard.damage = split [i];
				break;
			case 3:
				returnCard.charges = split [i];
				break;
			case 4:
				returnCard.cardType = split [i];
				break;
			case 5:
				returnCard.cardImage = split [i];
				break;
			default:
				Debug.Log ("THIS SHOULDNT HAPPEN!!!! BAD!!");
				break;
		}
	}
}
