using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;
    public bool isGettingAchievment = false;
    public bool clickTheAchievment = false;
    public bool alreadyGetAchievment = false;
    public int typeAchievment = 0;

    private void OnEnable() {
        EventManager.OnButtonIkanClicked += ClickButton;
        EventManager.OnGetAchievment += PlayGetAhievementAnimation;

        
    }

    private void OnDisable() {
        EventManager.OnButtonIkanClicked -= ClickButton;
        EventManager.OnGetAchievment -= PlayGetAhievementAnimation;
    }

    private void PlayAnimation() {
        isGettingAchievment = true;
        animator.SetBool("isGettingAchievment", isGettingAchievment);
        animator.SetInteger("typeAchievment", 1);
    }

    private void PlayGetAhievementAnimation() {
        if(!alreadyGetAchievment){
            isGettingAchievment = true;
            animator.SetBool("isGettingAchievment", isGettingAchievment);
            animator.SetInteger("Star", StarHolder.instance.totalStar);
        }else{
            isGettingAchievment = false;
            animator.SetBool("isGettingAchievment", isGettingAchievment);
        }
    }   
    public void PlayClickedAnimation() {
        clickTheAchievment = true;
        alreadyGetAchievment = true;
        animator.SetBool("clickTheAchievment", clickTheAchievment);
        animator.SetBool("isalreadyGetAchievment", alreadyGetAchievment);
    }

    private void ClickButton() {
       animator.SetInteger("typeAchievment", 0);
    }
}
