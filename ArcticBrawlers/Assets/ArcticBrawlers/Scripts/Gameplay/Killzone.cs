using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MultiplayerThirdPersonControl>())
        {
            SpawnManager.Instance.KillPlayer(other.GetComponent<MultiplayerThirdPersonControl>());
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
