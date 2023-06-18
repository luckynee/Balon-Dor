using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public CloudAnimator cloudAnimator;
    public float transitionDelay = 3f;
    public string nextSceneName;

    public void StartSceneTransition(int index)
    {
        
        StartCoroutine(TransitionDelayCoroutine(index));
    }

    private IEnumerator TransitionDelayCoroutine(int nextSceneIndex)
    {
        cloudAnimator.cloudAnimator1.SetBool("start", true);
        cloudAnimator.cloudAnimator2.SetBool("start", true);
        cloudAnimator.PlayCloudAnimation();
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
