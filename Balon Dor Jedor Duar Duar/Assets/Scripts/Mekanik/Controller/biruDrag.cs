using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biruDrag : MonoBehaviour
{
    public int iDWarna;
    public SoundRandomizer soundRandomizer;
    Vector2 startPos, slotPos;

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
        startDrag = true; 
        soundRandomizer.hitAudioGantiWarnaPrimer();
        inColBiru = true;
    }

    public void StopDragUI()
    {
        startDrag = false;
        inColBiru = false;
        transform.position = startPos;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
       
        if (collision.CompareTag("Slot2"))
        {
            inColKuning = true;
            startDrag = false ;
            inColMerah = false;
            slotPos = collision.transform.position;
            transform.position = slotPos;
            soundRandomizer.hitAudioGantiWarnaSekunder();
        }else  if (collision.CompareTag("Slot"))
        {
            inColBiru = false;
            startDrag = false ;
            inColMerah = true;
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
