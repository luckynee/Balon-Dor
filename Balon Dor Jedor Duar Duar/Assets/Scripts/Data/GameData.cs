using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<int> star;
    public List<int> levelCompleted;
    public List<int> levelUnlocked;
    public List<int> achievement;
    string listValue;
    

    public GameData(){
        this.star = new List<int>() {0, 0, 0,
                                     0, 0, 0,
                                     0, 0, 0};
        this.levelCompleted = new List<int>();
        this.levelUnlocked = new List<int>();
        this.achievement = new List<int>();
        
    }
    
}
