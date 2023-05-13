using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Balon_Merah : BalonParent , IPointerDownHandler
{
   public virtual void OnPointerDown (PointerEventData eventData) 
    {
       if(ctrl.iDPeluru == 1){
            Destroy(target, 0.3f);
        }else
        {
        }
    }


}
