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
            string[] split = loadedString.Split(delim);

            string title = "";
            int cost = 0, damage = 0, charges = 0;
            PunchType type = 0;
            Sprite sprite = null;

            for (int i = 0; i < split.GetLength(0); i++)
            {
                switch (i)
                {
                    case 0:
                        title = split[i];
                        break;
                    case 1:
                        cost = System.Convert.ToInt32(split[i]);
                        break;
                    case 2:
                        damage = System.Convert.ToInt32(split[i]);
                        break;
                    case 3:
                        charges = System.Convert.ToInt32(split[i]);
                        break;
                    case 4:
                        type = (PunchType)System.Convert.ToInt32(split[i]);
                        break;
                    case 5:
                        sprite = loadImage(split[i]);
                        break;
                    default:
                        Debug.Log("THIS SHOULDNT HAPPEN!!!! BAD!!");
                        break;
                }
            }

            Card readCard = new Card(title, cost, damage, charges, type, sprite);

            returnDeck.Push(readCard);
        }

		return returnDeck;
	}

	private static Sprite loadImage (string path)
	{
		return Resources.Load <Sprite> (path);
	}
}
