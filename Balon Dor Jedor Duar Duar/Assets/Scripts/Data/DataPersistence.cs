using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistence : MonoBehaviour
{
    public List<int> levelCompleted = new List<int>();
    public List<int> levelUnlocked = new List<int>();
    public List<int> achievement = new List<int>();
    public List<IDataPersistence> dataPersistenceObjects;
    private GameData gameData;
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

    public void NewGame(){
        this.gameData = new GameData();
    }
    public void LoadGame(){
        if(this.gameData == null)
        {  
            Debug.Log("No data was found");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded star count = " + gameData.star);
    }
    public void SaveGame(){
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved star count = " + gameData.star);
    }

    private void Start() {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit() {
        SaveGame();
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

    public void SetAchievement(int index)
    {
        if(!achievement.Contains(index))
            achievement.Add(index);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = 
        FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
