using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TempController : NetworkBehaviour {

    public float movementSpeed = 5f;
    public float turnSpeed = 45f;

    Rigidbody localRigidbody;

	// Use this for initialization
	void Start () {

        //If this is not the localplayer destroy this script.
        if(!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        localRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float turnAmount = Input.GetAxis("Horizontal");
        float moveAmount = Input.GetAxis("Vertical");

        Vector3 deltaTranslation = transform.position + transform.forward * movementSpeed * moveAmount * Time.deltaTime;
        localRigidbody.MovePosition(deltaTranslation);

        Quaternion deltaRotation = Quaternion.Euler(turnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
        localRigidbody.MoveRotation(localRigidbody.rotation * deltaRotation);
	}
}
