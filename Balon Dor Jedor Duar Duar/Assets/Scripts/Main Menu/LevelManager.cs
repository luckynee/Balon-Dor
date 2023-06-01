using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public StarHolder starHolder;
    public GameObject[] levelCompleted;
    public GameObject[] levelLocked;
    public GameObject[] levelUnlocked;
    public static LevelManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        starHolder = FindObjectOfType<StarHolder>();
    }

    public int GetCurrentLevel(){
        return SceneManager.GetActiveScene().buildIndex;
    }
    
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
