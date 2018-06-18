using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerColor : NetworkBehaviour {

    [SyncVar]
    public Color color;

    SkinnedMeshRenderer[] rends;

	// Use this for initialization
	void Start () {

        rends = GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = color;
        }
	}
	
	public void Hide()
    {
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.clear;
        }
    }
}
