using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LevelCompleted(int level);
    public static event LevelCompleted OnLevelCompleted;
    public delegate void LevelUnlocked(int level);
    public static event LevelUnlocked OnLevelUnlocked;
    public delegate void GetStar(int star);
    public static event GetStar OnGetStar;
    public delegate void GetAchievment();
    public static event GetAchievment OnGetAchievment;
    public delegate void ButtonClicked();
    public static event ButtonClicked OnButtonIkanClicked;

    public static void LevelComplete(int level)
    {
        OnLevelCompleted?.Invoke(level);
    }
    
    public static void UnlockedLevel(int level)
    {
        OnLevelUnlocked?.Invoke(level);
    }

    public static void GetAchievmentButtonClicked()
    {
        OnButtonIkanClicked?.Invoke();
    }

    public static void GetAchievmentAnim()
    {
        OnGetAchievment?.Invoke();
    }

    public static void GetTheStar(int star)
    {
        OnGetStar?.Invoke(star);
    }    
}
