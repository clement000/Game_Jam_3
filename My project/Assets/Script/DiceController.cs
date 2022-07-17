using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public float jumpDuration = 0.1f;    
    
    private bool isJumping = false;
    private Vector3 jumpDirection;
    private Vector3 jumpRotationAxis;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float jumpTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(1.8f, 0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            transform.position += Time.deltaTime / jumpDuration * 1.2f * jumpDirection;
            transform.RotateAround(transform.position, jumpRotationAxis, Time.deltaTime / jumpDuration * 90f);
            jumpTimer += Time.deltaTime;

            if (jumpTimer > jumpDuration)
            {
                isJumping = false;
                transform.localPosition = originalPosition + 1.2f * jumpDirection;
                transform.rotation = originalRotation;
                transform.RotateAround(transform.position, jumpRotationAxis, 90f);
            }
        }
        else
        {
            if (Input.GetKeyDown("z"))
            {
                isJumping = true;
                jumpDirection = new Vector3(0, 0, 1);
                jumpRotationAxis = new Vector3(1, 0, 0);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
            }
            else if (Input.GetKeyDown("q"))
            {
                isJumping = true;
                jumpDirection = new Vector3(-1, 0, 0);
                jumpRotationAxis = new Vector3(0, 0, 1);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
            }
            else if (Input.GetKeyDown("d"))
            {
                isJumping = true;
                jumpDirection = new Vector3(1, 0, 0);
                jumpRotationAxis = new Vector3(0, 0, -1);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
            }
            else if (Input.GetKeyDown("s"))
            {
                isJumping = true;
                jumpDirection = new Vector3(0, 0, -1);
                jumpRotationAxis = new Vector3(-1, 0, 0);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
            }
        }
    }
}
