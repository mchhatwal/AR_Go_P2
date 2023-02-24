using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public static Seeds instance;
    public List<GameObject> tree;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        tree = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
