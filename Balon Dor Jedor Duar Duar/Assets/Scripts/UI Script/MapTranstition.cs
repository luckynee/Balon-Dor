using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTranstition : MonoBehaviour
{
    public Animator bottomCornerCloudAnimator;
    public Animator topCornerCloudAnimator;

    public Image bottomCloud;
    public Image topCloud;
    public GameObject waitAnimationUntilEnd;

    public bool isAnimationPlaying = false;

    private void Start() {

        bottomCornerCloudAnimator = bottomCloud.GetComponent<Animator>();
        topCornerCloudAnimator = topCloud.GetComponent<Animator>();

        bottomCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
        topCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
    }
    public void LetsTransition() {
        if(!isAnimationPlaying){
            StartCoroutine(TranstitionToLevel());
        }
    }

    IEnumerator TranstitionToLevel(){
        isAnimationPlaying = true;
        bottomCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
        topCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
        waitAnimationUntilEnd.SetActive(isAnimationPlaying);
        yield return new WaitForSeconds(1.1f);

        isAnimationPlaying = false;
        bottomCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
        topCornerCloudAnimator.SetBool("isChanging", isAnimationPlaying);
        yield return new WaitForSeconds(1.8f);
        waitAnimationUntilEnd.SetActive(isAnimationPlaying);
    }

}
