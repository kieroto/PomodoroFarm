using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] public GameObject timer;
    [SerializeField] public GameObject promptwindow;
    private bool window_active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disable_pause();   
    }

    public void Start_bttn(){
        timer.GetComponent<Timer>().StartTimer();
    }

    public void Pause_bttn(){
        timer.GetComponent<Timer>().StopTimer();
    }
     
    public void Reset_bttn(){
        
        if(promptwindow.GetComponent<PromptWindow>().reset_flag == true){
            timer.GetComponent<Timer>().StopTimer();
            timer.GetComponent<Timer>().Start();
            promptwindow.GetComponent<PromptWindow>().reset_flag = false;
            timer.GetComponent<Timer>().reset_flag = true;
            untoggle_prompt();
        }
        else{
            promptwindow.GetComponent<PromptWindow>().prompt_call();
            toggle_prompt();   
        }
           
    }

    public void disable_pause(){
        if(timer.GetComponent<Timer>().breakActive == true || window_active == true)
            this.transform.GetChild(2).GetComponent<Button>().interactable = false;        
        else    
            this.transform.GetChild(2).GetComponent<Button>().interactable = true;
    }

    public void toggle_prompt(){
        window_active = true;
    }

    public void untoggle_prompt(){
        window_active = false;
    }
}
