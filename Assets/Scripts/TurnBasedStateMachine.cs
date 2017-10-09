using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState {
    START,
    LOCALTURN,
    REMOTETURN,
    RESOLVEEFFECTS,
    ENDGAME
}

public class TurnBasedStateMachine : MonoBehaviour {

    public TurnState currentState;

	// Use this for initialization
	void Start () {
        currentState = TurnState.START;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentState);

        switch(currentState)
        {
            case TurnState.START:
                break;
            case TurnState.LOCALTURN:
                break;
            case TurnState.REMOTETURN:
                break;
            case TurnState.RESOLVEEFFECTS:
                break;
            case TurnState.ENDGAME:
                break;
            default:
                break;
        }
	}
}
