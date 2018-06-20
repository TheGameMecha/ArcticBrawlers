using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class PlatformIcePhysics : MonoBehaviour {
    public float modifier = 1.0f;


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<ThirdPersonCharacter>())
        {
            GameObject go = other.gameObject;

            Vector3 addition = new Vector3(transform.rotation.x * 10, 0, transform.rotation.z * 10);
            
           go.GetComponent<ThirdPersonCharacter>().ApplyIcePhysics(addition * modifier);
        }
    }
}
