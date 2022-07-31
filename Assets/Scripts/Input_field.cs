using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class Input_field : MonoBehaviour
{

    public string value;
    [SerializeField] public GameObject inputField;
    [SerializeField] public GameObject textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void store_value(){
        value = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>.text
    }
}
