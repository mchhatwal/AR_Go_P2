using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSquirrel : MonoBehaviour
{
    public bool IsInteractiveMode = false;
    public AudioClip sfx;
    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    private void Start()
    {
        transform.localScale = Vector3.one * 800;
    }
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
