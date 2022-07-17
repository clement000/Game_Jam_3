using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCube : MonoBehaviour
{
    private bool spawned = false;
    private float decay;

    public float decayTime = 1f;
    public float distYTuile = 1f;
    
    public Rigidbody rb;
    public Animator mAnimator;
    
    void Update()
    {
        Reset();

        if (Input.GetKeyDown(KeyCode.D) && !spawned)
        {
            decay = decayTime;
            spawned = true;
                        
            rb.velocity = new Vector3(distYTuile/decayTime, 0, 0);
            mAnimator.SetTrigger("PushLeft");
        }

        if (Input.GetKeyDown(KeyCode.Q) && !spawned)
        {
            decay = decayTime;
            spawned = true;
            rb.velocity = new Vector3(-distYTuile / decayTime, 0, 0);
            mAnimator.SetTrigger("PushRight");
        }
    }

    private void Reset()
    {
        if (spawned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if (decay < 0)
        {
            decay = 0;
            spawned = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

}
