using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelCompleted;
    public GameObject[] levelLocked;
    public GameObject[] levelUnlocked;
    
    
    private void Update() {
        foreach (int level in DataPersistence.instance.levelCompleted)
        {
            levelCompleted[level].SetActive(true);
        }

        foreach (int level in DataPersistence.instance.levelUnlocked)
        {
            levelUnlocked[level].SetActive(true);
            levelLocked[level].SetActive(false);
        }
    }
}
