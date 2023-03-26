using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GambarIkanClicked : MonoBehaviour
{
    public void OnClickButton()
    {   
        Debug.Log("Button clicked");
        EventManager.GetAchievmentButtonClicked();
    }
}
