using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public StarHolder starHolder;
    public GameObject setLastActivePanel;
    public GameObject[] levelCompleted;
    public GameObject[] levelLocked;
    public GameObject[] levelUnlocked;
    public GameObject[] starLevelUnlocked;
    
    public GameObject[]starObjectLevel1;
    public GameObject[] starObjectLevel2;
    public GameObject[] starObjectLevel3;
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
            if(levelCompleted[0].activeSelf){
                starObjectLevel1[StarHolder.instance.star[0]].SetActive(true);
            }
            if(levelCompleted[1].activeSelf){
                starObjectLevel2[StarHolder.instance.star[1]].SetActive(true);
            }
            if(levelCompleted[2].activeSelf){
                starObjectLevel3[StarHolder.instance.star[2]].SetActive(true);
            }
            
        }

        foreach (int level in DataPersistence.instance.levelUnlocked)
        {
            levelUnlocked[level].SetActive(true);
            starLevelUnlocked[level].SetActive(true);
            levelLocked[level].SetActive(false);
        }

        
        // foreach(bool panel in DataPersistence.instance.panelActive){
        //     if(panel == true){
        //         setLastActivePanel.SetActive(true);
        //     }
        // }
    

        // foreach(int star in StarHolder.instance.star){
        //     if(star == 0){
        //         starObjectLevel1[0].SetActive(true);
        //         starObjectLevel2[0].SetActive(true);
        //         starObjectLevel3[0].SetActive(true);
        //     }
        //     if(star == 1){
        //         starObjectLevel1[1].SetActive(true);
        //         starObjectLevel2[1].SetActive(true);
        //         starObjectLevel3[1].SetActive(true);
        //     }
        //     if(star == 2){
        //         starObjectLevel1[2].SetActive(true);
        //         starObjectLevel2[2].SetActive(true);
        //         starObjectLevel3[2].SetActive(true);
        //     }
        //     if(star == 3){
        //         starObjectLevel1[3].SetActive(true);
        //         starObjectLevel2[3].SetActive(true);
        //         starObjectLevel3[3].SetActive(true);
        //     }
        // }

    }
}
