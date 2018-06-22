using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Make sure the object is spawned in the "Preload" scene (scene 0 in build index)
// This preload scene will only be loaded once when the game starts
public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private bool dontDestroyOnLoad = true;
    private int maxPlayers = 2;

    // Called on object creation
    void Awake()
    {
        // Singleton pattern
        // Makes sure there is only ever one GameManager object
        // Since we store data in this, we need to make sure it is used in the preload scene ONLY
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
        }

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject); // Keep the only manager alive across scenes
        }
    }

    public void SetMaxPlayers(int value)
    {
        maxPlayers = value;
    }

    public int GetMaxPlayers()
    {
        return maxPlayers;
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}