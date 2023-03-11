using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInDirectionOfMvmt : MonoBehaviour
{
    Vector3 previousPos; 

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 currPos = transform.position; 
        if (currPos == previousPos) { 
            return; 
        }

        Vector3 delta = currPos - previousPos; 
        delta = delta.normalized;

        transform.forward = delta; 

        previousPos = currPos; 
    }
}
