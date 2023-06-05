using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Balon_Hijau : BalonParent , IPointerDownHandler
{
   public virtual void OnPointerDown (PointerEventData eventData) 
    {
        if(ctrl.iDPeluru == 6){
           if(!isHit){
                isHit = true;
                animator.SetTrigger("Pop");
                Destroy(target, 0.5f);
                ctrl.score += 1;
                soundRandomizer.hitAudio();
            } 
        }else
        {
            soundRandomizer.hitAudioSalah();
        }
    }


}
