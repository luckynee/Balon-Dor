using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
    public GameObject pilihLevel;
    public GameObject mainMenu;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
    }

    // private void OnMouseDown() {
    //     if(!gameStart){ 
    //         GameStart();
    //     }
    // }

    void GameStart(){
        Debug.Log("game start");
        pilihLevel.SetActive(true);
        mainMenu.SetActive(false);
        gameStart = true;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !gameStart){
            GameStart();
        }
    }

}
