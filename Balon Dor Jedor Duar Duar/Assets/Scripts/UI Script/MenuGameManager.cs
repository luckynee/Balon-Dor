using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    public GameObject pilihLevel;
    public GameObject mainMenu;
    public MapTranstition mapTranstition;
    public bool gameStart;

    public void GameStart(){
        Debug.Log("game start");    
        mapTranstition.LetsTransition();
        StartCoroutine(JustWait());
        
    }

    public void BackToMenu(){
        mapTranstition.LetsTransition();
        StartCoroutine(Wait());
    }


    private void Update() {
        // if(Input.GetMouseButtonDown(0) && !gameStart){
        //     GameStart();
        // }
    }

    public void PlayGame(int levelIndex){
        mapTranstition.LetsTransition();
        StartCoroutine(waitBeforeChangeScene(levelIndex));
    }

    IEnumerator JustWait(){
        yield return new WaitForSeconds(1.6f);
        pilihLevel.SetActive(true);
        mainMenu.SetActive(false);
        gameStart = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.6f);
        pilihLevel.SetActive(false);
        mainMenu.SetActive(true);
        gameStart = false;
    }

    IEnumerator waitBeforeChangeScene(int levelIndex){
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(levelIndex);
    }
    
}
