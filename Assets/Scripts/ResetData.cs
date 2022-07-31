using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{

    [SerializeField] GameObject rewards_;
    [SerializeField] GameObject upgrades_;
    public GameObject[] farm_itemlist;
    RewardOrganizer rewards;
    UpgradeManager upgrades;
    // Start is called before the first frame update
    void Start()
    {
        rewards = rewards_.GetComponent<RewardOrganizer>();
        upgrades = upgrades_.GetComponent<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void delete_data()
    {
        Set_default_value();
        rewards.load();
        upgrades.load();
        destroy_items();
        upgrades.instantiate_firstload();
        rewards.coin.text = "0";
     //   rewards.GetComponent<RewardOrganizer>().Cycle.text = "Cycle : 0";
    }

    void Set_default_value()
    {
        PlayerPrefs.SetInt("task_count", 0);
        PlayerPrefs.SetInt("cycle_count", 0);
        PlayerPrefs.SetInt("coin_count", 0);

        PlayerPrefs.SetInt("Barn_lvl", 0);
        PlayerPrefs.SetInt("Puddle_lvl", 0);
        PlayerPrefs.SetInt("Berries_lvl", 0);
        PlayerPrefs.SetInt("Crop_lvl", 0);
        PlayerPrefs.SetInt("Fences_lvl", 0);
        PlayerPrefs.SetInt("Sunflower_lvl", 0);
        PlayerPrefs.SetInt("Tree_lvl", 0);
        PlayerPrefs.SetInt("Chicken_lvl", 0);
        PlayerPrefs.SetInt("Cow_lvl", 0);
        PlayerPrefs.SetInt("Sheep_lvl", 0);
        PlayerPrefs.SetInt("Pig_lvl", 0);

        PlayerPrefs.Save();

    }
    
    void destroy_items()
    {
        farm_itemlist = GameObject.FindGameObjectsWithTag("Farm_item");
        
        foreach (GameObject item in farm_itemlist)
        {
            Destroy(item);
            Debug.Log(item.name + " destroyed!");
        }
    }
}
