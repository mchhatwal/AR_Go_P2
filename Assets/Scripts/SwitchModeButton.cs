using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class SwitchModeButton : MonoBehaviour
{
    public GameObject gameplay_canvas; 

    static GameObject gameplay_canvas_instance; 
    
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

    public void OnSwitchButtonPressed()
    { 
        // based on current scene, switch to alternate scene
        // change button text when swapping scenes 
        // change audio clip to be played when swapping scenes
        if (SceneManager.GetActiveScene().name == "exploration_scene") 
        {
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

            int index = myseeds.tree.Count;
            int pos_index = myseeds.pos.Count;
            while(pos_index < index)
            {
                pos_index++;
                GameObject player = GameObject.Find("PlayerTarget");
                Vector3 randomvec = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
                myseeds.pos.Add(Vector3.zero + randomvec);
            }

            for(int i = 0; i < myseeds.tree.Count; i++)
            {
                GameObject obj = Instantiate(myseeds.tree[i]);
                obj.transform.position = myseeds.pos[i];
                obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            }
        } 
    }
}