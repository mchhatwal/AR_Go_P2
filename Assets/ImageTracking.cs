using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; 
using UnityEngine.XR.ARFoundation; 

public class ImageTracking : MonoBehaviour
{
    private GameObject[] objects; 
    // Update is called once per frame
    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Dollar");
        if (objects.Length == 1) 
        { 
            
        }
    }
}
