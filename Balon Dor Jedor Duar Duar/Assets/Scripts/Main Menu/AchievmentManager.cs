using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentManager : MonoBehaviour
{
    public GameObject[] button;
    public GameObject[] achievement;

    private void Update() {
        foreach(int i in DataPersistence.instance.achievement)
        {
            achievement[i].SetActive(true);
        }
        SetAchievementButton();
    }

    public void SetActiveAchievement(int index)
    {
        DataPersistence.instance.SetAchievement(index);
    }

    void SetAchievementButton()
    {
        if(StarHolder.instance.starLevelCarnival >= 6)
        {
            button[0].SetActive(true);
        }

        if(StarHolder.instance.starLevelBeach >= 6)
        {
            button[1].SetActive(true);
        }

        if(StarHolder.instance.starLevelPark >= 6)
        {
            button[2].SetActive(true);
        }
    }
}
