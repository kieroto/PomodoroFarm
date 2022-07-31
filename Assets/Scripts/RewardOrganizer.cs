using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class RewardOrganizer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject timer;
    [SerializeField] public Text coin;
//    [SerializeField] public Text Cycle;

    public SaveState state;

    public int task_count = 0;
    public int cycle_count = 0;
    public int coin_count;
    private int cycle_complete = 0;

    [SerializeField] public int serialized_COIN;
    [SerializeField] public bool enable_COIN_manipulate;


    public void load()
    {
        // task_count = SaveDataHolder.task;
        // cycle_count = SaveDataHolder.cycle;
        // task_count = PlayerPrefs.GetInt("task_count", 0);
        if(enable_COIN_manipulate)
            coin_count = serialized_COIN;
        else
            coin_count = PlayerPrefs.GetInt("coin_count", serialized_COIN);
        // Start();
    }

    void save()
    {
        // SaveDataHolder.task = task_count;
        // SaveDataHolder.cycle = cycle_count;
        // PlayerPrefs.SetInt("task_count", task_count);
        // PlayerPrefs.SetInt("cycle_count", cycle_count);
        PlayerPrefs.SetInt("coin_count", coin_count);
        PlayerPrefs.Save();
        Debug.Log("coin = " + coin_count);
    }

    void Start()
    {
        load();
        //Task.text = "Task : " +  task_count;
        //Cycle.text = "Cycle : " + cycle_count;
        coin.text = coin_count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer.GetComponent<Timer>().reset_flag == true){
            cycle_complete = 0;
            timer.GetComponent<Timer>().reset_flag = false;
        }

        if(timer.GetComponent<Timer>().taskFinish == true){
            task_count++;
            cycle_complete++;
            coin_count++;
            save();
            coin.text = coin_count.ToString();
            timer.GetComponent<Timer>().taskFinish = false;
        }

        if(timer.GetComponent<Timer>().breakFinish == true && cycle_complete < 4){   
            timer.GetComponent<Timer>().currentTime = (timer.GetComponent<Timer>().Minutes * 60) + 1;
            timer.GetComponent<Timer>().StartTimer();
            timer.GetComponent<Timer>().breakFinish = false;
        }

        if(cycle_complete == 4){
            cycle_count++;
            cycle_complete = 0;
            coin_count++;
            coin.text = coin_count.ToString();
            save();    
        
            Debug.Log("Cycle completed");
            timer.GetComponent<Timer>().breakActive = false;
            timer.GetComponent<Timer>().StopTimer();
            timer.GetComponent<Timer>().Start();
        }
    }
    
    public void Update_credit()
    {
        coin.text = coin_count.ToString();
    }
}
