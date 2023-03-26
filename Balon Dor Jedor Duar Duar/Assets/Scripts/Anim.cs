using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;
    public bool isGettingAchievment = false;
    public bool clickTheAchievment = false;
    public int typeAchievment = 0;

    private void OnEnable() {
        EventManager.OnLevelCompleted += PlayAnimation;
        EventManager.OnButtonIkanClicked += ClickButton;
    }

    private void OnDisable() {
        EventManager.OnLevelCompleted -= PlayAnimation;
        EventManager.OnButtonIkanClicked -= ClickButton;
    }

    private void PlayAnimation() {
        isGettingAchievment = true;
        animator.SetBool("isGettingAchievment", isGettingAchievment);
        animator.SetInteger("typeAchievment", 1);
    }

    private void ClickButton() {
       animator.SetInteger("typeAchievment", 0);
    }
}
