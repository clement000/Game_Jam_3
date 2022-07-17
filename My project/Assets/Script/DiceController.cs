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
    private int row;

    private int downFacingNumber;

    private Vector3[] initialFacingdirections = new[] { new Vector3(0, 0, -1), new Vector3(0, 1, 0), new Vector3(0, -1, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1) };
    private Vector3[] facingdirections = new[] { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), };

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(1.8f, 0.5f, 0);
        row = 3;
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
                // find the downfacing number
                Quaternion rotation = transform.rotation;
                for (int i = 0; i < 6; i++)
                {
                    facingdirections[i] = rotation * initialFacingdirections[i];
                    if (facingdirections[i] == new Vector3(0, -1, 0))
                    {
                        downFacingNumber = i + 1;
                    }
                }

                Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 1);
                try
                {
                    GateScript Gate = hit.transform.gameObject.GetComponent<GateScript>();
                    if (Gate.GateValue != downFacingNumber)
                    {
                        Gate.GameOver();
                        gameObject.AddComponent<Rigidbody>();
                    }
                } 
                catch
                {

                }
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
            else if (Input.GetKeyDown("q") && row > 0)
            {
                isJumping = true;
                jumpDirection = new Vector3(-1, 0, 0);
                jumpRotationAxis = new Vector3(0, 0, 1);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
                row -= 1;
            }
            else if (Input.GetKeyDown("d") && row < 3)
            {
                isJumping = true;
                jumpDirection = new Vector3(1, 0, 0);
                jumpRotationAxis = new Vector3(0, 0, -1);
                originalPosition = transform.localPosition;
                originalRotation = transform.rotation;
                jumpTimer = 0;
                row += 1;
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
