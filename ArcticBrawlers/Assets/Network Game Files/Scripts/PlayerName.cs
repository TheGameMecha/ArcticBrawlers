using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerName : NetworkBehaviour {

    [SyncVar]
    public string playerName;

	// Use this for initialization
	void Start () {
        Debug.Log(playerName + " has loaded into the game.");
	}
	
	
}
