using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

// A class that handles Spawning and the State of Players
public class SpawnManager : MonoBehaviour {

    // Serialized Variables
    [SerializeField]
    private GameObject playerPrefab;
    [Tooltip("Should have 4 Spawn points")]
    [SerializeField]
    private Transform[] spawnPoints;

    // Private Variables
    private int currentPlayers = 2;

    private PlayerID[] playerIDs = new PlayerID[] {PlayerID.One, PlayerID.Two, PlayerID.Three, PlayerID.Four};
    private LayerMask[] layerMasks = new LayerMask[] {9,10,11,12}; // 9-12 are the indexes of the layer masks in editor

    public static SpawnManager Instance { get; private set; }

    // Called on object creation
    void Awake()
    {
        // Singleton pattern
        // Makes sure there is only ever one GameManager object
        // Since we store data in this, we need to make sure it is used in the preload scene ONLY
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        currentPlayers = GameManager.Instance.GetMaxPlayers();
        SpawnPlayers();
	}

    void Update()
    {
        if (currentPlayers <= 1)
        {
            // TODO: End the game and award a point to the victor
            GameManager.Instance.LoadLevel(2);
        }
    }

    public void SpawnPlayers()
    {
        // Iterate through the number of players and assign their spawn points
        for (int x = 0; x < currentPlayers; x++)
        {
            if (x < spawnPoints.Length)
            {
                GameObject go = Instantiate(playerPrefab, spawnPoints[x].position, Quaternion.identity);
                MultiplayerThirdPersonControl player = go.GetComponent<MultiplayerThirdPersonControl>();

                player.SetPlayerID(playerIDs[x]);
                player.SetLayerMask(layerMasks[x]);
                player.SetDeadState(false);
            }
        }
    }

    public void SetNumPlayers(int value)
    {
        currentPlayers = value;
    }

    public void KillPlayer(MultiplayerThirdPersonControl player)
    {
        player.SetDeadState(true);
        currentPlayers -= 1;
    }
}