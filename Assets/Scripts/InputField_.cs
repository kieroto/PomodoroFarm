using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class InputField_ : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] GameObject credit;
    [SerializeField] public bool min_bool;
    [SerializeField] public bool task_bool;
    [SerializeField] public bool gold_;
    InputField m_InputField;
   // [SerializeField] public Text input_text;
    public static TouchScreenKeyboard keyboard;
    TimeSpan time;

    float minutes_f;
    float shortbreakminutes_f;
    string minutes, sec;
    string minutes_b, sec_b;
    string gold;

    public void change_text()
    {
        minutes = "" + timer.GetComponent<Timer>().Minutes;
        sec = "" + timer.GetComponent<Timer>().Seconds;
        minutes_b = "" + timer.GetComponent<Timer>().shortBreakMinutes;
        sec_b = "" + timer.GetComponent<Timer>().shortBreakSeconds;
        gold = "" + credit.GetComponent<RewardOrganizer>().coin_count;

        if(task_bool)
        {
            if(min_bool)
                m_InputField.text = minutes;
            else
                m_InputField.text = sec;
        }
        else
        {
            if(gold_)
                m_InputField.text = gold;
            else
            {
                if(min_bool)
                    m_InputField.text = minutes_b;
                else
                    m_InputField.text = sec_b;
            }
        

        }
    
    }
    public void close_kb()
    {
        keyboard.active = false;        
    }
    void Start()
    {
        //Fetch the Input Field component from the GameObject
        m_InputField = this.GetComponent<InputField>();
        //m_InputField.onClick.AddListener(TaskOnClick)
        
        change_text();
    }

    void Update()
    {

        //Check if the Input Field is in focus and able to alter
        // if (m_InputField.isFocused)
        // {
        //     //Change the Color of the Input Field's Image to green
        //     //m_InputField.GetComponent<Image>().color = Color.green;
        //     Debug.Log("Keyboard toggle");
        //     keyboard = TouchScreenKeyboard.Open(m_InputField.text, TouchScreenKeyboardType.NumberPad);
        //     Debug.Log(TouchScreenKeyboard.isInPlaceEditingAllowed);
        //     keyboard.characterLimit = 3;    

        // }
        // else
        // {
        //     if(keyboard!=null)
        //         keyboard.active = false;
        // }
    }


}
