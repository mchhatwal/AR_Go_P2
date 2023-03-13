using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSquirrel : MonoBehaviour
{
    public bool IsInteractiveMode = false;
    public AudioClip collideSfx;
    public AudioClip squirrelAttackSfx;
    private GameObject gameplay_canvas;
    float timer = 0f;
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
        AudioSource source = gameplay_canvas.GetComponent<AudioSource>();
        if (collision.gameObject.tag == "Acorn")
        {
            // play sfx for squirrel touch acorn 
            AudioSource.PlayClipAtPoint(collideSfx, Camera.main.gameObject.transform.position);


            // stop squirrel attack audio

            source.Stop();

            AudioClip clip = Resources.Load<AudioClip>("interact");

            // back to interact mode audio 
            source.PlayOneShot(clip);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Chocolate")
        {
            transform.localScale *= 2;
            AudioClip clip = Resources.Load<AudioClip>("chocolate");
            source.PlayOneShot(clip);
            Destroy(collision.gameObject);
        }

    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (!IsInteractiveMode)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        transform.localScale = Vector3.one * 300;
        if (timer >= 2.5f) gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
        else gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);

        if (timer >= 5f) timer -= 5f;
    }
}
