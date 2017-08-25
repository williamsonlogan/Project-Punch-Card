using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public static class LoadCSV
{
	public static Card Load (string file)
	{
		Card returnCard = new Card ();
		string loadedString;
		StreamReader sr = new StreamReader (file);
		loadedString = sr.ReadLine ();
		char[] delim = { ',' };

		string[] split = loadedString.Split (delim);

		for (int i = 0; i < split.GetLength (0); i++) {
			switch (i) {
			case 0:
				returnCard.cardTitle = split [i];
				break;
			case 1:
				returnCard.staminaCost = System.Convert.ToInt32 (split [i]);
				break;
			case 2:
				returnCard.damage = System.Convert.ToInt32 (split [i]);
				break;
			case 3:
				returnCard.charges = System.Convert.ToInt32 (split [i]);
				break;
			case 4:
				returnCard.cardType = (PunchType)System.Convert.ToInt32 (split [i]);
				break;
			case 5:
				returnCard.cardImage.sprite = loadImage (split [i]);
				break;
			default:
				Debug.Log ("THIS SHOULDNT HAPPEN!!!! BAD!!");
				break;
			}
		}

		return returnCard;
	}

	private static Sprite loadImage (string path)
	{
		return Resources.Load <Sprite> (path);
	}
}
