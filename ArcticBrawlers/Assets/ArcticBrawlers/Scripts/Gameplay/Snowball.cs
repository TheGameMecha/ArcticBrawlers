using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
[RequireComponent(typeof(Rigidbody))]
public class Snowball : MonoBehaviour {

    [SerializeField]
    private float knockbackForce = 2f;
    [SerializeField]
    private GameObject explosionEffect;

    private float moveSpeed = 1f;
    private Vector3 direction;
    private Rigidbody m_rigidbody;
    private Transform parentBone;
    private Transform FirePoint;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = true;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<ThirdPersonCharacter>())
        {
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            c.gameObject.GetComponent<ThirdPersonCharacter>().KnockBack(-dir, knockbackForce);
        }
        Explode();
    }

    public void SetLayerMask(LayerMask mask)
    {
        gameObject.layer = mask;
    }

    public void SetParentBone(Transform bone)
    {
        transform.parent = bone;
        parentBone = bone;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void ReleaseMe()
    {
        m_rigidbody.transform.parent = null;
        m_rigidbody.useGravity = true;
        m_rigidbody.isKinematic = false;

        //transform.rotation = parentBone.rotation;
        m_rigidbody.AddForce(transform.forward * 20000);
    }

    public void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
