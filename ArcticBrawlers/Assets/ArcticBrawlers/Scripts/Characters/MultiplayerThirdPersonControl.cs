﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;
using Luminosity.IO;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class MultiplayerThirdPersonControl : MonoBehaviour {

    public PlayerID playerID;
    private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private SnowballLauncher m_snowballLauncher; // A reference to the SnowballLauncher on the object

    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;                   // the world-relative desired move direction, calculated from the camForward and user input.
    private bool m_Jump;                      

    // Use this for initialization
    void Start () {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<ThirdPersonCharacter>();
        m_snowballLauncher = GetComponent<SnowballLauncher>();
    }
	
	// Update is called once per frame
	void Update () {

        // Jump

        if (!m_Jump)
        {
            m_Jump = Luminosity.IO.InputManager.GetButtonDown("Jump", playerID);
        }

        if (Luminosity.IO.InputManager.GetButtonDown("Throw",playerID)) // Throw a snowball
        {
            m_snowballLauncher.ThrowSnowball();
        }

        if (Luminosity.IO.InputManager.GetButtonDown("Reload", playerID)) // Pickup Snowball
        {
            m_snowballLauncher.ReloadSnowBall();
        }
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // read inputs from custom Input Manager
        float h = Luminosity.IO.InputManager.GetAxis("Horizontal", playerID);
        float v = Luminosity.IO.InputManager.GetAxis("Vertical", playerID);
        bool crouch = false;

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        // pass all parameters to the character control script
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
    }
}