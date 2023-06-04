using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public ControlManager ctrl;
    private GameObject isWinningPanel;
    public Animator animator;
    public WaveSpawner wave;
    public Text scoreText;
    public Text failText;
    public ads ads;
    public bool isPlaying;
    public bool isWinning;
    

    private string currentState;

    const string BINTANG0 = "bintang0";
    const string BINTANG1 = "bintang1";
    const string BINTANG2 = "bintang2";
    const string BINTANG3 = "bintang3"; 

    void Start(){
        ads.LoadInterstitialAd();  
        isWinningPanel = GameObject.Find("Win");
        isPlaying = true;
        isWinning = false;
    }

    void Update(){
        hitung();
        scoreText.text = ctrl.score.ToString();
        failText.text = ctrl.fail.ToString();   

        if(isWinning){
            EventManager.LevelComplete(LevelManager.instance.GetCurrentLevel() - 1);
            EventManager.UnlockedLevel(LevelManager.instance.GetCurrentLevel() - 1);
            if(StarHolder.instance.star[LevelManager.instance.GetCurrentLevel() - 1] < StarHolder.instance.getStar){
                StarHolder.instance.star[LevelManager.instance.GetCurrentLevel() - 1] = StarHolder.instance.getStar;
                Debug.Log("new star: " + StarHolder.instance.getStar);
            }
            isWinning = !isWinning;
        }

    }

    void hitung(){
        if(isPlaying){
            if(wave.totalEnemy % 2 == 0){
                if(ctrl.score == wave.totalEnemy){
                    ChangeAnimationState(BINTANG3);
                    StarHolder.instance.getStar = 3;
                    ads.ShowAd();
                    
                }else
                if(ctrl.score >= (wave.totalEnemy / 2)){
                    ChangeAnimationState(BINTANG2);
                    StarHolder.instance.getStar = 2;
                    ads.ShowAd();
                    
                }else
                if(ctrl.score < (wave.totalEnemy / 2)){
                    ChangeAnimationState(BINTANG1);
                    StarHolder.instance.getStar = 1;
                    ads.ShowAd();
                    
                }
            }else
            {
                if(ctrl.score == wave.totalEnemy){
                    ChangeAnimationState(BINTANG3);
                    StarHolder.instance.getStar = 3;
                    ads.ShowAd();
                    
                }else
                if(ctrl.score >= ((wave.totalEnemy + 1) / 2)){
                    ChangeAnimationState(BINTANG2);
                    StarHolder.instance.getStar = 2;
                    ads.ShowAd();
                    
                }else
                if(ctrl.score < ((wave.totalEnemy + 1) / 2)){
                    ChangeAnimationState(BINTANG1);
                    StarHolder.instance.getStar = 1;
                    ads.ShowAd();
                }
            }
            isPlaying = false;
            isWinning = true;
        }
        
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void Ads(){
        // ads.LoadInterstitialAd();     
        ads.ShowAd();
    }
}
