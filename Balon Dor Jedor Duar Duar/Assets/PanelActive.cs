using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActive : MonoBehaviour
{
   public GameObject[] panel;

   

   private void Update() {
        switch(DataPersistence.instance.lastActivePanel){
            case 0: 
                panel[0].SetActive(true);
                break;
            case 1:
                panel[1].SetActive(true);
                break;
            case 2:
                panel[2].SetActive(true);
                break;
            case 3:
                panel[3].SetActive(true);
                break;
            default:
                DataPersistence.instance.lastActivePanel = 5;
                break;

        }
    }

    public void SetPanelActive(int index){
        DataPersistence.instance.lastActivePanel = index;
    }
}
