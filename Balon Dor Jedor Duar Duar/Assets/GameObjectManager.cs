using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] UIOpenPanel;
    public GameObject[] UIClosePanel;
    public GameObject map;
    public MapTranstition mapTranstition;

    public void OpenPanel(int index)
    {
        mapTranstition.LetsTransition();
        StartCoroutine(Wait(index));
    }

    public void ClosePanel(int index)
    {
        mapTranstition.LetsTransition();
        StartCoroutine(WaitClose(index));
    }

    IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(1.6f);
        UIOpenPanel[index].SetActive(true);
        map.SetActive(false);
    }

    IEnumerator WaitClose(int index)
    {
        yield return new WaitForSeconds(1.6f);
        UIClosePanel[index].SetActive(false);
        map.SetActive(true);
    }
}
