using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public bool timerActive = false;
    public bool taskActive = false;
    public bool breakActive = false;
    public bool taskFinish = false;
    public bool breakFinish = false; 
    public bool reset_flag = false;

    public float currentTime;

    [SerializeField] public float Minutes;
    [SerializeField] public float Seconds;
    [SerializeField] public float shortBreakMinutes;
    [SerializeField] public float shortBreakSeconds;
    [SerializeField] public int cycles;
    [SerializeField] public float longBreakMinutes;
    [SerializeField] public Text currentTimeText;

    int intmin, intsec;
    string strmin, strsec;

    
    float formatter_min(bool flag)
    {
        if(flag)
            return Minutes + (Seconds/60);
        else
            return shortBreakMinutes + (shortBreakSeconds/60);
    }
    public void load()
    {
      //  Minutes = PlayerPrefs.Getfloat("t_min", 0.05);
      //  shortBreakMinutes = PlayerPrefs.Getfloat("s_min", 0.05);
    }

    public void save()
    {
        
    }

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log(Minutes+ ":min // " + Seconds + ":sec");
        if(breakActive == true)
            currentTime = (formatter_min(false) * 60) + 1;
        else
            currentTime = formatter_min(true) * 60;
        taskActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true){

            currentTime = currentTime - Time.deltaTime;

            if(breakActive == false)
                taskActive = true;

            if (currentTime <= 0){
                if(breakActive == false){
                    breakActive = true;
                    taskFinish = true;
                }
                else{
                    breakActive = false;
                    breakFinish = true;
                }
                timerActive = false;
                Start();
            }

            
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = formatter(time);
    }

    private string formatter(TimeSpan time){

        intmin = int.Parse(time.Minutes.ToString());
        intsec = int.Parse(time.Seconds.ToString());

        if(intmin<10)
            strmin = "0" + intmin.ToString();
        else
            strmin = intmin.ToString();

        if(intsec<10)
            strsec = "0" + intsec.ToString();
        else
            strsec = intsec.ToString();

    
        return strmin + ":" + strsec;
    }

    public void StartTimer(){
        timerActive = true;
    }

    public void StopTimer(){
        timerActive = false;
    }
}
