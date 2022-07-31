using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtons : MonoBehaviour
{
    //public SpriteRenderer renderer;
    // Start is called before the first frame update
    [SerializeField] public GameObject timer;

    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.touchCount > 0){
        
            Vector2 ray = new Vector2 ( Camera.main.ScreenToWorldPoint(Input.touches[0].position).x , Camera.main.ScreenToWorldPoint(Input.touches[0].position).y);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.x, ray.y), Vector2.zero, 0f);
            
            if(Input.touches[0].phase == TouchPhase.Began){
                    
                if(hit.collider != null){
                    if(hit.collider.name == "Start"){
                      ///  Debug.Log("Start started");
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(.7f,.7f,.7f);
                    }
                        
                    else if(hit.collider.name == "Pause"){
                       // Debug.Log("Stop started");
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(.7f,.7f,.7f);
                    }

                    else if(hit.collider.name == "Reset"){
                       // Debug.Log("Stop started");
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(.7f,.7f,.7f);
                    }
                        
                }
            }

            if(Input.touches[0].phase == TouchPhase.Ended){
                
                if(hit.collider != null){
                    if(hit.collider.name == "Start"){
                       // Debug.Log("Start ended");
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
                        timer.GetComponent<Timer>().StartTimer();
                    }
                        
                    else if(hit.collider.name == "Pause"){
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
                        //Debug.Log("Stop ended");
                        timer.GetComponent<Timer>().StopTimer();
                    }

                    else if(hit.collider.name == "Reset"){
                       // Debug.Log("Stop started");
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1f, 1f,1f);
                        timer.GetComponent<Timer>().StopTimer();
                        timer.GetComponent<Timer>().Start();
                    }
                        
                }
            }
                         
        }
    }
}
