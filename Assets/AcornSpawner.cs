using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public GameObject acorn_prefab; 
    public AudioClip sfx; 
    public float acorn_launch_velo = 1.0f; 

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     // change logic to launch if acorn button clicked (find tree logic)
    //     if (Input.GetKeyDown(KeyCode.Space)) { 
    //         LaunchAcorn(); 

    //         // play sfx for throwing acorn 
    //     }
    // }


    public void LaunchAcorn() 
    { 
        // add logic for checking if acorns are in inventory to throw 
        // need more than 0 acorns to launch at least 1 

        Vector3 spawn_pos = Camera.main.gameObject.transform.position; 
        GameObject new_acorn = GameObject.Instantiate(acorn_prefab, spawn_pos, Quaternion.identity); 
        new_acorn.GetComponent<Rigidbody>().velocity = Camera.main.gameObject.transform.forward * acorn_launch_velo; 
        
        // play sfx for throwing acorn 
        AudioSource.PlayClipAtPoint(sfx, Camera.main.gameObject.transform.position); 
    }
}
