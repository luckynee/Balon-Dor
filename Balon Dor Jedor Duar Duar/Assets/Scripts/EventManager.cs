using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LevelCompleted();
    public static event LevelCompleted OnLevelCompleted;
    public delegate void ButtonClicked();
    public static event ButtonClicked OnButtonIkanClicked;

    public static void LevelComplete()
    {
        OnLevelCompleted?.Invoke();
    }

    public static void GetAchievmentButtonClicked()
    {
        OnButtonIkanClicked?.Invoke();
    }
}
