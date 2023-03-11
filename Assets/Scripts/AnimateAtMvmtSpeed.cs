using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAtMvmtSpeed : MonoBehaviour
{
    Vector3 previousPos; 
    Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position; 
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 currPos = transform.position; 
        Vector3 delta = currPos - previousPos; 
        float mvmtSpeed = delta.magnitude; 
        float mvmtRatio = mvmtSpeed / 0.0728f; 

        animator.speed = mvmtRatio; 
        previousPos = currPos; 
    }
} 
