using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    [SerializeField] GameObject savedata;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

       // Debug.Log(Helper.Serializer<SaveState>(state));
    }

    void set()
    {
        state.task = SaveDataHolder.task;
        state.cycle = SaveDataHolder.cycle;
    }

    void load_to_game()
    {
        SaveDataHolder.task = state.task;
        SaveDataHolder.cycle = state.cycle;        
    }
    public void Save()
    {
        set();
        Debug.Log("save - " + state.task);
        PlayerPrefs.SetString("save", Helper.Serializer<SaveState>(state));
        PlayerPrefs.Save();
    }

    public void Load()
    {
        //PlayerPrefs.DeleteKey("save");
        if (PlayerPrefs.HasKey("save"))
        {   
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            load_to_game();
            savedata.GetComponent<RewardOrganizer>().load();
            Debug.Log("load - " + state.task);
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("Empty. Save data created.");
        }
    }
    
    public static void static_save()
    {
        SaveManager j = new SaveManager();
        j.Save();
    }
    void OnDestroy()
    {
        Save();
    }
}
