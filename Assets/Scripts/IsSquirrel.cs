using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSquirrel : MonoBehaviour
{
    public AudioClip sfx; 
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag != "Acorn")
        { 
            return; 
        }

        // play sfx for squirrel touch acorn 
        AudioSource.PlayClipAtPoint(sfx, Camera.main.gameObject.transform.position); 
        Destroy(collision.gameObject); 
        Destroy(gameObject);
    }
}
