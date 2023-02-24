using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;


public class UpdateCurrency : MonoBehaviour
{
    public static int currency; 
    private GameObject[] objects; 
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // update currency based on current value 
        objects = GameObject.FindGameObjectsWithTag("Dollar");
        if (objects.Length == 1) 
        { 
            // extra bonus for finding Ann Arbor Crest Image 
            currency += 100; 
        }

        GetComponent<TMP_Text>().text = "$" + currency.ToString(); 
    }
}
