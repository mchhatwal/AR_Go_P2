using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SquirrelAttack : MonoBehaviour
{
    public GameObject gameplay_canvas; 

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // beginning of work for attacking squirrel in interaction mode (not complete)

        if (SceneManager.GetActiveScene().name == "interaction_scene")
        { 
            // if squirrel near tree, perform squirrel game object actions 
            // Task: Gameobject: Squirrel from a2go_tasks sheet 
            
            // start music for attacking squirrel (play until squirrel defeated)
            // only start if squirrel found near tree 
            // pseudocode: while (attacking squirrel) 
            
            // AudioSource source = gameplay_canvas.GetComponent<AudioSource>();
            // source.Stop(); 

            // AudioClip clipStart = Resources.Load<AudioClip>("fight");

            // // after switching scenes, play new audio
            // source.PlayOneShot(clipStart); 

            
            // do work for squirrel attack here!!! 
            
            
            // once squirrel destroyed, go back to interact music 
            // AudioSource sourceEnd = gameplay_canvas.GetComponent<AudioSource>();
            // sourceEnd.Stop(); 

            // AudioClip clipEnd = Resources.Load<AudioClip>("interact");

            // // after switching scenes, play new audio
            // sourceEnd.PlayOneShot(clipEnd); 
        }
    }
}
