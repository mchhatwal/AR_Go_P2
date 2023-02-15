using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform player_avatar; 
    public Vector3 offset; 

    // Update is called once per frame
    void Update()
    {
        transform.position = player_avatar.position + offset; 
    }
}
