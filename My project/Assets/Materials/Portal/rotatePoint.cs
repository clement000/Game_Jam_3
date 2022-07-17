using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePoint : MonoBehaviour
{
    public GameObject target;

    public Vector3 rotationDirection;
    public float speed;

    void Update()
    {
        transform.RotateAround(target.transform.position, rotationDirection, speed * Time.deltaTime);
        
    }
}