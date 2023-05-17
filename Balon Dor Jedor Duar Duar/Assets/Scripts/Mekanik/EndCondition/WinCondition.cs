using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public ControlManager ctrl;
    public Animator animator;
    public WaveSpawner wave;
    public Text scoreText;
    public Text failText;

    private string currentState;

    const string BINTANG0 = "bintang0";
    const string BINTANG1 = "bintang1";
    const string BINTANG2 = "bintang2";
    const string BINTANG3 = "bintang3"; 

    void Start(){        
    }

    void Update(){
        hitung();
        scoreText.text = ctrl.score.ToString();
        failText.text = ctrl.fail.ToString();   
    }

    void hitung(){

        if(wave.totalEnemy % 2 == 0){
            if(ctrl.score == wave.totalEnemy){
                ChangeAnimationState(BINTANG3);
            }else
            if(ctrl.score >= (wave.totalEnemy / 2)){
                ChangeAnimationState(BINTANG2);
            }else
            if(ctrl.score < (wave.totalEnemy / 2)){
                ChangeAnimationState(BINTANG1);
            }
        }else
        {
            if(ctrl.score == wave.totalEnemy){
                ChangeAnimationState(BINTANG3);
            }else
            if(ctrl.score >= ((wave.totalEnemy + 1) / 2)){
                ChangeAnimationState(BINTANG2);
            }else
            if(ctrl.score < ((wave.totalEnemy + 1) / 2)){
                ChangeAnimationState(BINTANG1);
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
