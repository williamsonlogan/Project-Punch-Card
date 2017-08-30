using UnityEngine;
using System.IO;

public static class LoadCSV
{
	public static Deck Load (string file)
	{
		Deck returnDeck = new Deck("", 10);

		string loadedString;
		StreamReader sr = new StreamReader (file);
		loadedString = sr.ReadLine ();
		char[] delim = { ',' };

        returnDeck.Title = loadedString;

        while ((loadedString = sr.ReadLine()) != null)
        {
            Card readCard = new Card();
            string[] split = loadedString.Split(delim);

            for (int i = 0; i < split.GetLength(0); i++)
            {
                switch (i)
                {
                    case 0:
                        readCard.cardTitle = split[i];
                        break;
                    case 1:
                        readCard.staminaCost = System.Convert.ToInt32(split[i]);
                        break;
                    case 2:
                        readCard.damage = System.Convert.ToInt32(split[i]);
                        break;
                    case 3:
                        readCard.charges = System.Convert.ToInt32(split[i]);
                        break;
                    case 4:
                        readCard.cardType = (PunchType)System.Convert.ToInt32(split[i]);
                        break;
                    case 5:
                        readCard.cardImage = loadImage(split[i]);
                        break;
                    default:
                        Debug.Log("THIS SHOULDNT HAPPEN!!!! BAD!!");
                        break;
                }
            }

            returnDeck.Push(readCard);
        }

		return returnDeck;
	}

	private static Sprite loadImage (string path)
	{
		return Resources.Load <Sprite> (path);
	}
}
