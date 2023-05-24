using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    public GameObject pilihLevel;
    public GameObject mainMenu;
    public bool gameStart;

    void GameStart(){
        Debug.Log("game start");    
        pilihLevel.SetActive(true);
        mainMenu.SetActive(false);
        gameStart = true;
    }

    public void BackToMenu(){
        Debug.Log("back to menu");
        pilihLevel.SetActive(false);
        mainMenu.SetActive(true);
        gameStart = false;
    }


    private void Update() {
        if(Input.GetMouseButtonDown(0) && !gameStart){
            GameStart();
        }
    }

    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    
}
