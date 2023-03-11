using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (UserInventory.instance.acorn_count > 0 && SceneManager.GetActiveScene().name != "exploration_scene")
        {
            // Vector3 spawn_pos = Camera.main.gameObject.transform.position;
            Vector3 spawn_pos = GameObject.FindGameObjectWithTag("MainCamera").transform.position; 
            GameObject new_acorn = GameObject.Instantiate(acorn_prefab, spawn_pos, Quaternion.identity);
            new_acorn.GetComponent<Rigidbody>().velocity = Camera.main.gameObject.transform.forward * acorn_launch_velo;

            // play sfx for throwing acorn 
            AudioSource.PlayClipAtPoint(sfx, Camera.main.gameObject.transform.position);
        }
    }
}
