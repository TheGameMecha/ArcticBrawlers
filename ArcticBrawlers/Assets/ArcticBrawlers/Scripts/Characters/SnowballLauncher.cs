using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Luminosity.IO;

public class SnowballLauncher : MonoBehaviour {

    [SerializeField]
    private float throwSpeed = 1.0f;

    [SerializeField]
    private float cooldownSpeed = 2.0f;
    private bool isCoolingDown = false;
    private bool snowballLoaded = true;

    [SerializeField]
    private GameObject snowballPrefab;

    [SerializeField]
    private Transform snowballHolder; //This is the transform that holds the snowball, usually a hand of some sort

    private float cooldownTimer = 0f;

    private Snowball currentSnowball;

    private Animator animator;

    void Start()
    {
        LoadSnowball();
        animator = GetComponent<Animator>();
    }

    public void LoadSnowball()
    {
        currentSnowball = Instantiate(snowballPrefab, snowballHolder).GetComponent<Snowball>();
        currentSnowball.SetParentBone(snowballHolder);
        currentSnowball.SetLayerMask(gameObject.layer);
        snowballLoaded = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (isCoolingDown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer > cooldownSpeed)
            {
                isCoolingDown = false;
                cooldownTimer = 0f;
            }
        }
	}

    public void ThrowSnowball()
    {
        if (isCoolingDown == false)
        {
            // throw the snowball forward

            animator.SetTrigger("Throw");
            isCoolingDown = true;
        }
    }

    public void ReleaseSnowBall()
    {
        // This method is only to be called by the animator
        if (currentSnowball == null)
            return;

        snowballLoaded = false;
        currentSnowball.ReleaseMe();
        currentSnowball = null;
    }

    public void ReloadSnowBall()
    {
        // TODO: Assign a new snowball to the hand
        if (snowballLoaded)
            return;

        snowballLoaded = true;
        animator.SetTrigger("Pickup");
    }
}
