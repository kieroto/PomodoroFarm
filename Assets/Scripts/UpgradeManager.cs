using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    /*

        Barn - lvl
        Animals - lvl, qty
        plants - lvl
        Fence - lvl
        Decor - lvl
    */    

    [SerializeField] public GameObject credit;
    [SerializeField] public GameObject instantiator;
    
    public GameObject Barn_, Animals_, Plants_, Fence_, Decor_;

    public class item{

        //public string type;
        //public string kind;
        public int qty;
        public int lvl;
        public int price;

    };

    public item Barn, Animals, Plants, Fence, Decor;
    
    public void load()
    {
        Barn.lvl = PlayerPrefs.GetInt("barn_lvl", 1);
        Animals.lvl = PlayerPrefs.GetInt("animals_lvl", 1);
        Plants.lvl = PlayerPrefs.GetInt("plants_lvl", 1);        
        Fence.lvl = PlayerPrefs.GetInt("fence_lvl", 1);
        Decor.lvl = PlayerPrefs.GetInt("decor_lvl", 1);
    }

    void save()
    {
        PlayerPrefs.SetInt("barn_lvl", Barn.lvl);
        PlayerPrefs.SetInt("animals_lvl", Animals.lvl);
        PlayerPrefs.SetInt("plants_lvl", Plants.lvl);
        PlayerPrefs.SetInt("fence_lvl", Fence.lvl);
        PlayerPrefs.SetInt("decor_lvl", Decor.lvl);
        PlayerPrefs.Save();

    }

    void price_set()
    {
        Barn.price = 2;
        Animals.price = 2;
        Plants.price = 2;
        Fence.price = 2;
        Decor.price = 2;
    }
    void Start()
    {
        Barn = new item();
        Animals = new item();
        Plants = new item();
        Fence = new item();
        Decor = new item();
        load();
        price_set();
        instantiate_firstload();
        //declare variables for prefab then instantiate through instantiator method;
    }

    public void instantiate_firstload()
    {
        //if(Barn.lvl > 0)
          //  Barn_ = instantiator.GetComponent<Instantiator_>().instantiate("Test_item (" + Barn.lvl + ")");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void barn_upgrade()
    {
        int cap = 3;
        if(credit.GetComponent<RewardOrganizer>().coin_count >= 2)
        {
            if(Barn.lvl < cap)
            {
                credit.GetComponent<RewardOrganizer>().coin_count-=2;
                credit.GetComponent<RewardOrganizer>().Update_credit();
                Barn.lvl++;
                save();

              //  instantiator.GetComponent<Instantiator_>().destroy_test_obj();
              //  Barn_ = instantiator.GetComponent<Instantiator_>().instantiate("Test_item (" + Barn.lvl + ")");
        
                //pass instantiated prefab to an instantiator method that destroys it;
                //declare variable and instantiate a prefab through instantiator method;
            }
            else
            {
                Debug.Log("Max level reached");
            }

        }
        else
        { 
            Debug.Log("Not enough credit");
        }
    }


}





















