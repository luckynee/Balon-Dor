using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;
    public bool isGettingAchievment = false;
    public bool clickTheAchievment = false;
    public bool alreadyGetAchievment = false;
    public int trigerButtonActive;

    private void OnEnable() {
        EventManager.OnGetAchievment += PlayGetAhievementAnimation;
    }   

    private void OnDisable() {
        EventManager.OnGetAchievment -= PlayGetAhievementAnimation;
    }


    private void PlayGetAhievementAnimation() {
        isGettingAchievment = true;
        animator.SetBool("isGettingAchievment", isGettingAchievment);
        animator.SetInteger("StarCarnival", StarHolder.instance.starLevelCarnival);
        animator.SetInteger("StarBeach", StarHolder.instance.starLevelBeach);
        animator.SetInteger("StarPark", StarHolder.instance.starLevelPark);
        
    }   
    public void PlayClickedAnimation() {
        clickTheAchievment = true;
        alreadyGetAchievment = true;
        animator.SetBool("clickTheAchievment", clickTheAchievment);
        animator.SetBool("isalreadyGetAchievment", alreadyGetAchievment);
    }

}
