using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System;
using Random = System.Random;

public class Upgrader : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public GameObject credit;
    [SerializeField] public GameObject instantiator;
    [SerializeField] public int cap;
    [SerializeField] public int price;
    [SerializeField] public bool isLivestock;
    GameObject item;
    int lvl, suffx;

    float x, y;
    Vector3 spawn_pos;
    Random _rand = new Random();
    int Roll()
    {
        return _rand.Next(1, 100);
    }
    
    void load()
    {
        lvl = PlayerPrefs.GetInt(this.name+"_lvl", 0);
    }
    
    void save()
    {
        PlayerPrefs.SetInt(this.name+"_lvl", lvl);
        PlayerPrefs.Save();
    }

    void Start()
    {
        load();
        credit.GetComponent<RewardOrganizer>().load();

        if(lvl != 0)
            instantiate_firstload();
        if(lvl==cap || credit.GetComponent<RewardOrganizer>().coin_count < price)
            this.GetComponent<Button>().interactable = false;
        else
            this.GetComponent<Button>().interactable = true;

        this.GetComponent<Button>().onClick.AddListener(upgrade_item);
        //Debug.Log(this.name+"_lvl = " + lvl + ",  coin = " + credit.GetComponent<RewardOrganizer>().coin_count);
    }

    void instantiate_firstload()
    {
        // Debug.Log("FirstLoad instantiate " + this.name  + " " + lvl);
        if(isLivestock)
        {   
            
            Debug.Log(suffx);
            for (int i = lvl; i < cap; i++)
            {
                suffx = (int)Math.Ceiling( (Roll()/100f) * 4.0f);
                item = instantiator.GetComponent<Instantiator_>().instantiate(this.name+"_"+suffx, isLivestock);
                x = (Roll()/100f) * 5.75f;
                y = (Roll()/100f) * 3.3f;
                spawn_pos = new Vector3(x, y, 0.0f);
                item.transform.localPosition = spawn_pos;
            }
                
        }
        else
            item = instantiator.GetComponent<Instantiator_>().instantiate(this.name+"_"+lvl, isLivestock);
    }

    void Update()
    {
        if(credit.GetComponent<RewardOrganizer>().coin_count < price || lvl >= cap)
                this.GetComponent<Button>().interactable = false;
        else    
                this.GetComponent<Button>().interactable = true;    

    }

    void upgrade_item()
    {
        if(credit.GetComponent<RewardOrganizer>().coin_count >= price)
        {
            if(lvl<cap){
                credit.GetComponent<RewardOrganizer>().coin_count-=2;
                credit.GetComponent<RewardOrganizer>().Update_credit();
                lvl++;
                save();
                if(lvl!=0 && !isLivestock)
                {
                    Destroy(item);
                    suffx = lvl;
                    item = instantiator.GetComponent<Instantiator_>().instantiate(this.name+"_"+suffx, isLivestock);
                }
                   
                else
                {
                    suffx = (int)Math.Ceiling( (Roll()/100f) * 4.0f);
                    item = instantiator.GetComponent<Instantiator_>().instantiate(this.name+"_"+suffx, isLivestock);
                    x = (Roll()/100f) * 5.75f;
                    y = (Roll()/100f) * 3.3f;
                    spawn_pos = new Vector3(x, y, 0.0f);
                    item.transform.localPosition = spawn_pos;
                }
                    
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
                Debug.Log("Max lvl reached for this item!");
            }

        }
        else
        {
            this.GetComponent<Button>().interactable = false;
            Debug.Log("Not enough credit!");
        }
        
    }

}
