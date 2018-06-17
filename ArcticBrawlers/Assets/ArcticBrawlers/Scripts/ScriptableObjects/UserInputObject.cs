using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "User Input", menuName = "Data/Input", order = 1)]
public class UserInputObject : ScriptableObject {

    [Header("Basic Info")]
    public int playerID;

    [Header("Input Manager Values")]

    public string horizontalMovement;
    public string verticalMovement;
    public string jumpButton;
    public string throwSnowball;
    public string reloadSnowball;
    public string pauseButton;
}
