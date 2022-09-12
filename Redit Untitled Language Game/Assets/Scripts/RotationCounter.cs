using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCounter : MonoBehaviour
{
 
    Quaternion rotationThis;
    // Start is called before the first frame update
    void Start()
    {
        rotationThis = transform.rotation;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.rotation = rotationThis;
    }
}
