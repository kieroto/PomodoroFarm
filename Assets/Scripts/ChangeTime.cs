using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class ChangeTime : MonoBehaviour
{
    private Color temp;
//    private float perc, a_perc;
  //  private float duration = 3f;
    //private float elapsed_time;
    // private float set_alpha;
    // private float alpha_level, alpha_start;


    private Vector2 destination;
    public bool reset_flag = false;
    
    [SerializeField] public float distance;
    [SerializeField] GameObject menu_buttons;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject credit;
    [SerializeField] InputField task_min;
    [SerializeField] InputField task_sec;
    [SerializeField] InputField break_min;
    [SerializeField] InputField break_sec;
    [SerializeField] InputField gold;
    // [SerializeField] GameObject InputField_;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = destination;

        if(timer.GetComponent<Timer>().taskActive == true || timer.GetComponent<Timer>().breakActive == true)
            menu_buttons.transform.GetChild(5).GetComponent<Button>().interactable = false;
    

    }

    public void save_bttn(){
        destination.y = destination.y + distance;
        //elapsed_time = 0;
        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }  

        reset_flag = true;
        menu_buttons.GetComponent<Buttons>().Reset_bttn();
        menu_buttons.GetComponent<Buttons>().untoggle_prompt();

        // task 
        timer.GetComponent<Timer>().Minutes = float.Parse(task_min.text);
        timer.GetComponent<Timer>().Seconds = float.Parse(task_sec.text);
        timer.GetComponent<Timer>().shortBreakMinutes = float.Parse(break_min.text);
        timer.GetComponent<Timer>().shortBreakSeconds = float.Parse(break_sec.text);
        credit.GetComponent<RewardOrganizer>().coin_count = int.Parse(gold.text);
        //reinitialize
        credit.GetComponent<RewardOrganizer>().Update_credit();
        timer.GetComponent<Timer>().StopTimer();
        timer.GetComponent<Timer>().Start();


        
    }

    public void cancel_bttn(){
        destination.y = destination.y + distance;
        //elapsed_time = 0;

        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }  

        menu_buttons.GetComponent<Buttons>().untoggle_prompt();
        reset_flag = false;
    }

    public void prompt_call(){

        destination.y = destination.y - distance;
      //  elapsed_time = 0;

        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        menu_buttons.GetComponent<Buttons>().toggle_prompt();
        //InputField_.GetComponent<InputField_>().change_text();
    }

    public void test(){
        Debug.Log("Opened");
        TouchScreenKeyboard keyboard;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
 }
