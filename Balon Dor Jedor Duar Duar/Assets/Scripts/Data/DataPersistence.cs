using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistence : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private FileDataHandler dataHandler;

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
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {  
            Debug.Log("No data was found");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        string listValue = string.Join(", ", gameData.star);
        Debug.Log("Loaded star count = " + listValue);
    }
    public void SaveGame(){
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        string listValue = string.Join(", ", gameData.star);
        Debug.Log("Saved star count = " + listValue);

        dataHandler.Save(gameData);
    }

    private void Start() {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        Debug.Log("Data path: " + Application.persistentDataPath);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus){
            SaveGame();
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
