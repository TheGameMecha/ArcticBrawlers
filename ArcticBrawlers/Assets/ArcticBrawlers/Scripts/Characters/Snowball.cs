using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Snowball : MonoBehaviour {


    private float moveSpeed = 1f;
    private Vector3 direction;

    private Rigidbody m_rigidbody;

    private Transform parentBone;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
        
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

        transform.rotation = parentBone.rotation;
        m_rigidbody.AddForce(transform.forward * 20000);
    }
}
