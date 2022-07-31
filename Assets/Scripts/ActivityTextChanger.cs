using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class ActivityTextChanger : MonoBehaviour
{
    [SerializeField] public Text activity;
    //GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Timer>().breakActive == false){
            
            activity.text = "Task";
            if (this.GetComponent<Timer>().taskActive == false)
                activity.color = Color.red;
            else{
                if (this.GetComponent<Timer>().timerActive == true)
                    activity.color = Color.green;
                else
                    activity.color = Color.yellow;
                
            }
                
        }
        else{
            activity.text = "Break";
            activity.color = Color.yellow;
            this.GetComponent<Timer>().StartTimer();
        }
    }
}
