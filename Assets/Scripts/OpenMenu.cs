using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class OpenMenu : MonoBehaviour
{
    Vector2 current_pos, default_pos;
    private float duration = 1f;
    private float elapsed_time;
    [SerializeField] public float distance;
    [SerializeField] public GameObject Buttons_;
    // Start is called before the first frame update
    void Start()
    {
        default_pos = transform.localPosition;
        current_pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed_time += Time.fixedDeltaTime;
        float perc = elapsed_time / duration;
        
        transform.localPosition = Vector2.Lerp(transform.localPosition, current_pos, Mathf.SmoothStep(0,1, perc));
        
        if (Input.GetKeyDown(KeyCode.Escape)){
        //    SaveManager.static_save();
            Application.Quit(); 
        }
    }

    public void bttn_clicked(){
        Debug.Log("Toggle menu");
        if(current_pos.x == default_pos.x)
            current_pos.x = current_pos.x - distance;
        else
            current_pos.x = current_pos.x + distance;
        
        for(int i = 0; i < 6; i++){
            Buttons_.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
       
        elapsed_time = 0;
                 
    }


}
