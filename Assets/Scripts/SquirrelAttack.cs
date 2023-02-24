using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SquirrelAttack : MonoBehaviour
{
    public GameObject gameplay_canvas; 
    private GameObject[] gameObjects; 
    private List<GameObject> squirrels; 

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
            // grab all objects present in scene (should contain 1 tree and 1 nearby squirrel)
            gameObjects = SceneManager.GetSceneByName("interaction_scene").GetRootGameObjects(); 
            
            // code to find all squirrels and track if 1 destroyed (need to fix)
            // foreach (GameObject object in gameObjects) 
            // { 
            //     if (object.tag == "Squirrel") 
            //     {
            //         squirrels.Add(object); 
            //     } 
            // }
            // private int num_squirrels = squirrels.Count; 
            // private int destroyed_count = num_squirrels - 1; 
            
            // if squirrel near tree, perform squirrel game object actions 
            // Task: Gameobject: Squirrel from a2go_tasks sheet 
            
            // start music for attacking squirrel (play until squirrel defeated)
            // only start if squirrel found near tree 
            // while (attacking squirrel), play music 
            
            // AudioSource source = gameplay_canvas.GetComponent<AudioSource>();
            // source.Stop(); 

            // AudioClip clipStart = Resources.Load<AudioClip>("fight");

            // // after switching scenes, play new audio
            // source.PlayOneShot(clipStart); 

            
            // do work for squirrel attack here!!! 
            
            
            // once squirrel destroyed, go back to interact music 
            // if (num_squirrels == destroyed_count)
            // { 
            //     // AudioSource sourceEnd = gameplay_canvas.GetComponent<AudioSource>();
            //     // sourceEnd.Stop(); 

            //     // AudioClip clipEnd = Resources.Load<AudioClip>("interact");

            //     // // after switching scenes, play new audio
            //     // sourceEnd.PlayOneShot(clipEnd); 
            // }
        }
    }
}
