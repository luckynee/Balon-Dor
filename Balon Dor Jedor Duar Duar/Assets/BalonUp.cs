using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonUp : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 2f);

        if(transform.position.y < -195f)
            Destroy(gameObject);
    }
}
