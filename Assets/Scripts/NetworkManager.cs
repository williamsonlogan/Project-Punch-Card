using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Connect ();
	}
	
	void Connect () {
		PhotonNetwork.ConnectUsingSettings ("testver");
	}

	void OnGUI() {
		Debug.Log (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
