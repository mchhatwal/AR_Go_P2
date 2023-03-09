using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSquirrel : MonoBehaviour
{
    public bool IsInteractiveMode = false;
    public AudioClip collideSfx;
    public AudioClip squirrelAttackSfx;
    private GameObject gameplay_canvas; 
    // public GameObject gameplay_canvas;
    // // Start is called before the first frame update
    //void Start()
    //{

    //}

    // // Update is called once per frame
    // void Update()
    // {
    private void Start()
    {
        transform.localScale = Vector3.one * 800;
        gameplay_canvas = GameObject.Find("GameplayCanvas"); 

        // start squirrel audio when squirrel spawned + in interactive mode
        if (IsInteractiveMode)
        {
            AudioSource source = gameplay_canvas.GetComponent<AudioSource>();
            source.Stop();

            // stop interact mode, play squirrel attack music 
            source.PlayOneShot(squirrelAttackSfx);
        }
    }
    // }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag != "Acorn")
        { 
            return; 
        }

        // play sfx for squirrel touch acorn 
        AudioSource.PlayClipAtPoint(collideSfx, Camera.main.gameObject.transform.position);
        Destroy(collision.gameObject);
        Destroy(gameObject);

        // stop squirrel attack audio
        AudioSource source = gameplay_canvas.GetComponent<AudioSource>();
        source.Stop();

        AudioClip clip = Resources.Load<AudioClip>("interact");

        // back to interact mode audio 
        source.PlayOneShot(clip); 
    }

    private void Update()
    {
        if (!IsInteractiveMode)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        transform.localScale = Vector3.one * 300;
        GetComponent<BoxCollider>().isTrigger = false;
        if (Time.frameCount % 500 <= 250) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
    }
}
