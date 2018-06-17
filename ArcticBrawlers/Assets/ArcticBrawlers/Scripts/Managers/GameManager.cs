using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    private UserInputObject[] playerInputs;

    // Called on object creation
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
        }
    }
}
