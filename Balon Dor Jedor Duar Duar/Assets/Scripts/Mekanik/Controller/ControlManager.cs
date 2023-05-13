using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ControlManager : MonoBehaviour 
{
    public merahDrag merah;
    public kuningDrag kuning;
    public biruDrag biru;
    private int tempPeluru;

    
    [HideInInspector] 
    public int iDPeluru;
    public bool desMerah , desBiru , desKuning;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        iDPeluru = tempPeluru;
       
        Merah();
        Kuning();
        Biru();

        Debug.Log("ID peluru"+iDPeluru);
        

    }

    void Merah(){
        if(merah.inColMerah == true){
            tempPeluru = 1;
        
        }else
        if(merah.inColBiru == true){
            tempPeluru = 4;
           
        }else
        if(merah.inColKuning == true){
            tempPeluru = 5;
      
        }
    }

    void Kuning(){
        if(kuning.inColKuning == true){
            tempPeluru = 2;
        }else
        if(kuning.inColBiru == true){
            tempPeluru = 6;
        }else
        if(kuning.inColMerah == true){
            tempPeluru = 5;
        }
    }

    void Biru(){
        if(biru.inColBiru == true){
            tempPeluru = 3;
        }else
        if(biru.inColKuning == true){
            tempPeluru = 6;
        }else
        if(biru.inColMerah == true){
            tempPeluru = 4;
        } 
    }

}
