using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Random = System.Random;

public class Instantiator_ : MonoBehaviour
{
   // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    // [SerializeField] public GameObject myPrefab;
    [SerializeField] public GameObject grid_;
    
    GameObject obj;
    GameObject obj_load;

    float x, y;

    Vector3 spawn_pos;
    //private bool flag = false;

    Random _rand = new Random();
    int Roll()
    {
        return _rand.Next(1, 100);
    }

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        
        
    }

    public void call(){
        // if(flag == false)
        //     instantiate();
        // else
        //     destroy_test_obj();
    }
    public GameObject instantiate(string prefab_name, bool isLivestock){
        
        obj_load = Resources.Load<GameObject>(prefab_name);
        
        obj = Instantiate(obj_load, obj_load.transform.position, Quaternion.identity, grid_.transform);

        if(isLivestock){
            // x = obj.transform.position.x + Random.Range(0.0f, 5.93f);
            // y = obj.transform.position.y + Random.Range(0.0f, 3.4f);

            x = (Roll()/100f) * 5.93f;
            y = (Roll()/100f) * 3.4f;
            spawn_pos = new Vector3(x, y, 0.0f);
            obj.transform.localPosition = spawn_pos;
        }
            
        //test_obj = Instantiate(myPrefab, myPrefab.transform.position, Quaternion.identity);

        // flag = true;
        return obj;
    }

    public void destroy_test_obj(GameObject _obj){
        Destroy(_obj);
        // flag = false;
    }
}
