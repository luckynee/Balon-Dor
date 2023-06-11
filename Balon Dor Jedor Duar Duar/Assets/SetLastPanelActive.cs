using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLastPanelActive : MonoBehaviour
{
    public int lastActivePanel;
    private void OnEnable() {
        SetLastPanel(lastActivePanel);
    }

    private void SetLastPanel(int index){
        DataPersistence.instance.lastActivePanel = index;
    }
}
