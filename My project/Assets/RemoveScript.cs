using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    private float length;
    // Start is called before the first frame update
    void Start()
    {
        length = gameObject.GetComponent<Properties>().length;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -20-length)
        {
            Destroy(gameObject);
        }
    }
}
