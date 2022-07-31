using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class PromptWindow : MonoBehaviour
{
    private Color temp;
    private float perc, a_perc;
    private float duration = 1f;
    private float elapsed_time;
    // private float set_alpha;
    // private float alpha_level, alpha_start;


    private Vector2 destination;
    public bool reset_flag = false;
    
    [SerializeField] public float distance;
    // [SerializeField] public float duration_out;
    // [SerializeField] public float duration_in;
    [SerializeField] GameObject menu_buttons;
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

        // transform.GetChild(0).GetComponent<CanvasGroup>().alpha = Mathf.Lerp(alpha_start, alpha_level, Mathf.SmoothStep(0,1, perc));
        
        // set_alpha = Mathf.Lerp(alpha_start, alpha_level, Mathf.SmoothStep(0,1, perc));
        // temp = this.GetComponent<SpriteRenderer>().color;
        // temp.a = set_alpha;

        // this.GetComponent<SpriteRenderer>().color = temp;
    }

    public void yes_bttn(){
        destination.y = destination.y + distance;
        elapsed_time = 0;
        // alpha_level = 0;
        // alpha_start = 1;
        // duration = duration_out;

        for(int i = 0; i < 6 ; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }  

        reset_flag = true;
        menu_buttons.GetComponent<Buttons>().Reset_bttn();
    }

    public void no_bttn(){
        destination.y = destination.y + distance;
        elapsed_time = 0;
        // alpha_level = 0;
        // alpha_start = 1;
        // duration = duration_out;
        
        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }  

        menu_buttons.GetComponent<Buttons>().untoggle_prompt();
        reset_flag = false;
    }

    public void prompt_call(){

        destination.y = destination.y - distance;
        // alpha_level = 1;
        // alpha_start = 0;
        // duration = duration_in;
        elapsed_time = 0;

        for(int i = 0; i < 6; i++){
            menu_buttons.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
    }
}
