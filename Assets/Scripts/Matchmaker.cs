using UnityEngine;

public class Matchmaker : MonoBehaviour {

    GameObject Player;
    GameObject OppPlayer;

    int NumRounds;

	// Use this for initialization
	void Start () {
        Player = (GameObject)Instantiate(Resources.Load("Prefabs/Player"));
        Player.transform.parent = GameObject.Find("Canvas").transform;
        Player.GetComponent<Player>().IsOppPlayer = false;

        OppPlayer = (GameObject)Instantiate(Resources.Load("Prefabs/Player"));
        OppPlayer.transform.parent = GameObject.Find("Canvas").transform;
        OppPlayer.GetComponent<Player>().IsOppPlayer = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
