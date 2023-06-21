using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;
    public bool isGettingAchievment = false;
    public bool clickTheAchievment = false;
    public bool alreadyGettingAchievement = false;
    public int trigerButtonActive;

    private void OnEnable() {
        EventManager.OnGetAchievment += PlayGetAhievementAnimation;
    }   

    private void OnDisable() {
        EventManager.OnGetAchievment -= PlayGetAhievementAnimation;
    }


    private void PlayGetAhievementAnimation() {
        animator.SetInteger("StarCarnival", StarHolder.instance.starLevelCarnival);
        animator.SetInteger("StarBeach", StarHolder.instance.starLevelBeach);
        animator.SetInteger("StarPark", StarHolder.instance.starLevelPark);
        animator.SetBool("alreadyGettingAchievement", alreadyGettingAchievement);
    }   
    public void PlayClickedAnimation() {
        clickTheAchievment = true;
        alreadyGettingAchievement = true;
        animator.SetBool("clickTheAchievment", clickTheAchievment);
        animator.SetBool("alreadyGettingAchievement", alreadyGettingAchievement);
    }

}
