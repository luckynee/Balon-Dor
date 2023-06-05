using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonUp : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 2f);

        if(transform.position.y > 12f || transform.position.x < -12f)
            Destroy(gameObject);
    }
}
