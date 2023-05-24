using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LevelCompleted(int level);
    public static event LevelCompleted OnLevelCompleted;
    public delegate void LevelUnlocked(int level);
    public static event LevelUnlocked OnLevelUnlocked;
    public delegate void ButtonClicked();
    public static event ButtonClicked OnButtonIkanClicked;

    public static void LevelComplete(int level)
    {
        Debug.Log("dfefefefef");
        OnLevelCompleted?.Invoke(level);
    }
    
    public static void LevelLock(int level)
    {
        OnLevelUnlocked?.Invoke(level);
    }

    public static void GetAchievmentButtonClicked()
    {
        OnButtonIkanClicked?.Invoke();
    }
}
