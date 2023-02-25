using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SwitchModeButton : MonoBehaviour
{
    public GameObject gameplay_canvas;
    public AbstractMap map;
    public static GameObject gameplay_canvas_instance;
    public GameObject tree_object;

    public void Start() 
    { 
        if (gameplay_canvas_instance == null) 
        { 
            gameplay_canvas_instance = gameplay_canvas;
            DontDestroyOnLoad(gameplay_canvas); 
        }
        else 
        { 
            Destroy(gameplay_canvas); 
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "exploration_scene" && GameObject.Find("PlayerTarget") != null && map != null)
            Seeds.User_location = map.WorldToGeoPosition(GameObject.Find("PlayerTarget").transform.position);
    }
    public void OnSwitchButtonPressed()
    { 
        // based on current scene, switch to alternate scene
        // change button text when swapping scenes 
        // change audio clip to be played when swapping scenes
        if (SceneManager.GetActiveScene().name == "exploration_scene") 
        {

            float shortest_distance = 50f;
            TreeInstance show_tree = null;
            foreach (TreeInstance tree in Seeds.instance.tree)
            {
                Vector3 user_position = GameObject.Find("PlayerTarget").transform.position;
                float distance = Vector3.Distance(user_position, tree.Obj.transform.position);
                if (distance < shortest_distance)
                {
                    shortest_distance = distance;
                    show_tree = tree;
                }
            }

            // change scene 
            SceneManager.LoadScene("interaction_scene"); 
            // change button 
            gameplay_canvas_instance.GetComponentInChildren<Text>().text = "Explore Mode";

            // grab current audio and stop playing 
            AudioSource source = gameplay_canvas_instance.GetComponent<AudioSource>();
            source.Stop(); 

            AudioClip clip = Resources.Load<AudioClip>("interact");

            // after switching scenes, play new audio
            source.PlayOneShot(clip);

            if(show_tree != null)
            {
                GameObject new_tree = Instantiate(show_tree.TreeType);
                new_tree.transform.localScale = Vector3.one * show_tree.scale;
            }


        } 

        else if (SceneManager.GetActiveScene().name == "interaction_scene") 
        {
            SceneManager.LoadScene("exploration_scene"); 
            gameplay_canvas_instance.GetComponentInChildren<Text>().text = "Interact Mode";  

            // grab current audio and stop playing 
            AudioSource source = gameplay_canvas_instance.GetComponent<AudioSource>();
            source.Stop(); 

            AudioClip clip = Resources.Load<AudioClip>("explore");

            // after switching scenes, play new audio
            source.PlayOneShot(clip);


        } 
    }
}