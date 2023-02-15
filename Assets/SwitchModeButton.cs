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
        
        if (SceneManager.GetActiveScene().name == "exploration_scene") 
        {
            SceneManager.LoadScene("interaction_scene"); 
            gameplay_canvas_instance.GetComponentInChildren<Text>().text = "Explore Mode"; 
        } 

        else if (SceneManager.GetActiveScene().name == "interaction_scene") 
        {
            SceneManager.LoadScene("exploration_scene"); 
            gameplay_canvas_instance.GetComponentInChildren<Text>().text = "Interact Mode";  
        } 

        // maybe play audio here once scene is switched to and loaded? 
    }
}
