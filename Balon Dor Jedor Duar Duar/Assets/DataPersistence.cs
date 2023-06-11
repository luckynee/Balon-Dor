using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public List<int> levelCompleted = new List<int>();
    public List<int> levelUnlocked = new List<int>();
    public int lastActivePanel;
    // public List<bool> panelActive = new List<bool>(){false}; 
    public static DataPersistence instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void AddLevelCompleted(int level){
        levelCompleted.Add(level);
    }

    public void AddUnlockedLevel(int level){
        levelUnlocked.Add(level);
    }

    public void SetForMainMenu(int index){
        lastActivePanel = index;
    }
}
