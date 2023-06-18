using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarHolder : MonoBehaviour, IDataPersistence
{
    public int getStar;
    public int totalStar;
    public List<int> star = new List<int>() {0, 0, 0, 0, 0, 0, 0, 0, 0};
    public int starLevelCarnival;  
    public int starLevelBeach;  
    public int starLevelPark;  

    public static StarHolder instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
     
        }
    }

    public void LoadData(GameData data)
    {
        this.star = data.star;
    }

    public void SaveData(ref GameData data)
    {
        data.star = this.star;
    }

    void CalculateStar(){
        totalStar = star.Sum();
        starLevelCarnival = star[0] + star[1] + star[2];
        starLevelBeach = star[3] + star[4] + star[5];
        starLevelPark = star[6] + star[7] + star[8];
        // Debug.Log("Total Bintang : " + totalStar);
        
        if(starLevelCarnival >= 6 || starLevelBeach >= 6 || starLevelPark >= 6){
            Debug.Log("Get Achievement");
            EventManager.GetAchievmentAnim();
        }
    }

    void CappedStar(){
         for(int i = 0; i < star.Count; i++){
            if(star[i] > 3){
                star[i] = 3;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CappedStar();
        CalculateStar();

    }

    
}
