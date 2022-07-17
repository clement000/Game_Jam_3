using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationPortal : MonoBehaviour
{
    public Transform mTransform;

    public Vector3 rotationDirection;
    public float speed;

    void Update()
    {
        
        mTransform.Rotate(rotationDirection * speed * Time.deltaTime);
    }
}
