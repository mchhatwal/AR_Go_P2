using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;


public class UpdateCurrency : MonoBehaviour
{
    public static int currency; 
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // update currency based on current value 
        GetComponent<TMP_Text>().text = "$" + currency.ToString(); 
    }
}
