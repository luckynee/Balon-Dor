using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public bool isCompleted = true;
    public int levelNumber = 3;
    public GameObject button;

    // masih ga guna
    public void CompleteLevel()
    {
        isCompleted = true;
        Debug.Log("Level " + levelNumber + " is completed!");
    }

    public void GetAchievment(){
        if (isCompleted && levelNumber == 3)
        {
            EventManager.LevelComplete();
            button.SetActive(true);
            Debug.Log("Level " + levelNumber + " is completed and you got an achievment!");
        }
    }

}
