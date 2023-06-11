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
    
    public GameObject[]carnivalStarLevel1;
    public GameObject[] carnivalStarLevel2;
    public GameObject[] carnivalStarLevel3;
    public GameObject[] beachStarLevel1;
    public GameObject[] beachStarLevel2;
    public GameObject[] beachStarLevel3;

    public GameObject[] parkStarLevel1;
    public GameObject[] parkStarLevel2;
    public GameObject[] parkStarLevel3;
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
        GetCarnivalStar();
        GetBeachStar();
        GetParkStar();

        foreach (int level in DataPersistence.instance.levelUnlocked)
        {
            if(level != 8){

                levelUnlocked[level].SetActive(true);
                starLevelUnlocked[level].SetActive(true);
                levelLocked[level].SetActive(false);
            }
        }

    }

    void GetCarnivalStar(){
        foreach (int level in DataPersistence.instance.levelCompleted)
        {
            levelCompleted[level].SetActive(true);
            if(levelCompleted[0].activeSelf){
                carnivalStarLevel1[StarHolder.instance.star[0]].SetActive(true);
            }
            if(levelCompleted[1].activeSelf){
                carnivalStarLevel2[StarHolder.instance.star[1]].SetActive(true);
            }
            if(levelCompleted[2].activeSelf){
                carnivalStarLevel3[StarHolder.instance.star[2]].SetActive(true);
            }
            
        }
    }

    void GetBeachStar(){
        foreach (int level in DataPersistence.instance.levelCompleted)
        {
            levelCompleted[level].SetActive(true);
            if(levelCompleted[3].activeSelf){
                beachStarLevel1[StarHolder.instance.star[3]].SetActive(true);
            }
            if(levelCompleted[4].activeSelf){
                beachStarLevel2[StarHolder.instance.star[4]].SetActive(true);
            }
            if(levelCompleted[5].activeSelf){
                beachStarLevel3[StarHolder.instance.star[5]].SetActive(true);
            }
            
        }
    }

    void GetParkStar(){
        foreach (int level in DataPersistence.instance.levelCompleted)
        {
            levelCompleted[level].SetActive(true);
            if(levelCompleted[6].activeSelf){
                parkStarLevel1[StarHolder.instance.star[6]].SetActive(true);
            }
            if(levelCompleted[7].activeSelf){
                parkStarLevel2[StarHolder.instance.star[7]].SetActive(true);
            }
            if(levelCompleted[8].activeSelf){
                parkStarLevel3[StarHolder.instance.star[8]].SetActive(true);
            }
            
        }
    }
}
