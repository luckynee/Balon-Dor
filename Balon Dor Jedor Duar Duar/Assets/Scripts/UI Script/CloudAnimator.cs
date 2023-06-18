using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimator : MonoBehaviour
{
    public Animator cloudAnimator1;
    public Animator cloudAnimator2;
    public bool changingScene = false;

    private void Start()
    {
        StopCloudAnimation();
    }

    public void PlayCloudAnimation()
    {
        changingScene = true;
        cloudAnimator1.SetBool("changingScene", changingScene);
        cloudAnimator2.SetBool("changingScene", changingScene);
    }

    public void StopCloudAnimation()
    {
        changingScene = false;
        cloudAnimator1.SetBool("changingScene", changingScene);
        cloudAnimator2.SetBool("changingScene", changingScene);
    }
}
