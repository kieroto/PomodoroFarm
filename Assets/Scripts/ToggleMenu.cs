using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    Vector2 curpos, pos;
    private float duration = 3.0f;
    private float elapsed_time;
    [SerializeField] public float distance;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.localPosition;
        curpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x == curpos.x)
            elapsed_time = 0;

        elapsed_time += Time.fixedDeltaTime;
        float perc = elapsed_time / duration;
        
        transform.localPosition = Vector2.Lerp(transform.localPosition, curpos, Mathf.SmoothStep(0,1, perc));


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            
            //Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Vector2 ray = new Vector2 ( Camera.main.ScreenToWorldPoint(Input.touches[0].position).x , Camera.main.ScreenToWorldPoint(Input.touches[0].position).y);
           
            //RaycastHit hit;
           // Debug.Log(ray.x);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.x, ray.y), Vector2.zero, 0f);
            
           // BoxCollider2D box = GetComponent<BoxCollider2D>();
            
            // if(Physics2D.Raycast(ray, out hit))
            // {
                 if(hit.collider != null && hit.collider.name == "MenuSlider"){
                     if(curpos.x == pos.x)
                         curpos.x = curpos.x - distance;
                     else
                         curpos.x = curpos.x + distance;
                 }
               
          //  }
            
                
        }
    }
}   
