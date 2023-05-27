using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuningDrag : MonoBehaviour
{
     public int iDWarna;
    Vector2 startPos, slotPos;
    public SoundRandomizer soundRandomizer;

    [HideInInspector] 
    public bool startDrag,inColBiru,inColKuning,inColMerah;
    


    // Start is called before the first frame update
    void Start()
    {   
        soundRandomizer = GameObject.Find("SFX").GetComponent<SoundRandomizer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        swapPeluru();
    }

    public void swapPeluru(){

       if(startDrag)
        {       
            transform.position = Input.mousePosition;
        }
    }
    

    public void StartDragUI()
    {
        soundRandomizer.hitAudioGantiWarnaPrimer();
        startDrag = true; 
        inColKuning = true;
    }

    public void StopDragUI()
    {
        startDrag = false;
        inColKuning = false;
        transform.position = startPos;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
       
        if (collision.CompareTag("Slot"))
        {
            inColKuning = false;
            startDrag = false ;
            inColMerah = true;
            slotPos = collision.transform.position;
            transform.position = slotPos;
            soundRandomizer.hitAudioGantiWarnaSekunder();

        }else  if (collision.CompareTag("Slot3"))
        {
            inColBiru = true;
            startDrag = false ;
            inColMerah = false;
            slotPos = collision.transform.position;
            transform.position = slotPos;
            soundRandomizer.hitAudioGantiWarnaSekunder();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        inColKuning = false;
        inColBiru = false;
        inColMerah = false;

    }
}
