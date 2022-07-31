using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class UpgradeWindow_ : MonoBehaviour
{
    private Color temp;
    private float perc, a_perc;
    private float duration = 3f;
    private float elapsed_time;
    // private float set_alpha;
    // private float alpha_level, alpha_start;


    private Vector2 destination;
    public bool reset_flag = false;
    
    [SerializeField] public float distance;
    [SerializeField] GameObject menu_buttons;
    //[SerializeField] GameObject menu_slider;
    [SerializeField] GameObject timer;

    [SerializeField] Button structure_bttn;
    [SerializeField] Button vegetation_bttn;
    [SerializeField] Button livestock_bttn;
    [SerializeField] Button exit_bttn;

    [SerializeField] GameObject structure_window;
    [SerializeField] GameObject vegetation_window;
    [SerializeField] GameObject livestock_window;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed_time += Time.fixedDeltaTime;
        perc = elapsed_time / 1f;
        a_perc = elapsed_time / duration;

        transform.localPosition = Vector2.Lerp(transform.localPosition, destination, Mathf.SmoothStep(0,1, perc));

        if(timer.GetComponent<Timer>().taskActive == true || timer.GetComponent<Timer>().breakActive == true)
            menu_buttons.transform.GetChild(5).GetComponent<Button>().interactable = false;
        // else
        //     menu_buttons.transform.GetChild(6).GetComponent<Button>().interactable = true;

    }

    // public void save_bttn(){
    //     destination.y = destination.y + distance;
    //     elapsed_time = 0;
    //     for(int i = 0; i < 6; i++){
    //         menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
    //     }  

    //     //reset_flag = true;
    //     menu_buttons.GetComponent<Buttons>().Reset_bttn();
    //     menu_buttons.GetComponent<Buttons>().untoggle_prompt();
        
    // }

    public void cancel_bttn(){
        destination.y = destination.y + distance;
        elapsed_time = 0;

        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }  

        menu_buttons.GetComponent<Buttons>().untoggle_prompt();
        //reset_flag = false;
    }

    public void prompt_call(){

        destination.y = destination.y - distance;
        elapsed_time = 0;

        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        menu_buttons.GetComponent<Buttons>().toggle_prompt();
    }

    public void immediate_close()
    {
        destination.y = destination.y + distance;
        this.transform.localPosition = destination;
    }

    public void test(){
        Debug.Log("Opened");
        TouchScreenKeyboard keyboard;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void disable_upgrade_bttns()
    {
        structure_bttn.GetComponent<Button>().interactable = false;
        vegetation_bttn.GetComponent<Button>().interactable = false;
        livestock_bttn.GetComponent<Button>().interactable = false;
        exit_bttn.GetComponent<Button>().interactable = false;
    }

    public void enable_upgrade_bttns()
    {
        structure_bttn.GetComponent<Button>().interactable = true;
        vegetation_bttn.GetComponent<Button>().interactable = true;
        livestock_bttn.GetComponent<Button>().interactable = true;
        exit_bttn.GetComponent<Button>().interactable = true;
    }

    public void open_structure_upgrades()
    {
        structure_window.transform.localPosition = new Vector3(-3.263803f, -0.9f, 0);
    }

    public void close_structure_upgrades()
    {
        structure_window.transform.localPosition = new Vector3(-3.263803f, 233.16f, 0);
    }

    public void open_vegetation_upgrades()
    {
        vegetation_window.transform.localPosition = new Vector3(-3.263803f, -0.9f, 0);
    }

    public void close_vegetation_upgrades()
    {
        vegetation_window.transform.localPosition = new Vector3(-3.263803f, 233.16f, 0);
    }

    
    public void open_livestock_upgrades()
    {
        livestock_window.transform.localPosition = new Vector3(-3.263803f, -0.9f, 0);
    }

    public void close_livestock_upgrades()
    {
        livestock_window.transform.localPosition = new Vector3(-3.263803f, 233.16f, 0);
    }
 }
