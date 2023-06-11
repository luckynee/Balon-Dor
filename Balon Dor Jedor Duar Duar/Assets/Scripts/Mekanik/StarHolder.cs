using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarHolder : MonoBehaviour
{
    public int getStar;
    public int totalStar;
    public List<int> star = new List<int>() {0, 0, 0, 0, 0, 0, 0, 0, 0};  

    public static StarHolder instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
     
        }
    }

    void CalculateStar(){
        totalStar = star.Sum();
        Debug.Log("Total Bintang : " + totalStar);
        
        if(totalStar >= 6){
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
