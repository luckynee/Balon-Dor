using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<int> star;

    public GameData(){
        this.star = new List<int>() {0, 0, 0,
                                     0, 0, 0,
                                     0, 0, 0};
    }
    
}
