using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    [HideInInspector] public bool firsttimeshow = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("CityCouncil");
        if (obj != null) transform.position = obj.transform.position + new Vector3(13, 0, -9);
    }
}
