using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{

    public GameObject acorn_prefab; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            LaunchAcorn(); 
        }
    }

    public float acorn_launch_velo = 1.0f; 

    void LaunchAcorn() 
    { 
        Vector3 spawn_pos = Camera.main.gameObject.transform.position; 
        GameObject new_acorn = GameObject.Instantiate(acorn_prefab, spawn_pos, Quaternion.identity); 
        new_acorn.GetComponent<Rigidbody>().velocity = transform.forward * acorn_launch_velo; 
    }
}
