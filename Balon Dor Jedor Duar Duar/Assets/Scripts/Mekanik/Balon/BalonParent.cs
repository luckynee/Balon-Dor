using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class BalonParent : MonoBehaviour
{
    public GameObject pecahSource;
    // public AudioSource pecah;

    public GameObject wrongSource;
    // public AudioSource wrong;

    public GameObject target;
    public ControlManager ctrl;
    public Animator animator;

    public float  kecepatan;
    private Rigidbody2D rb;
    public bool isHit;

    public int colorId;

   void Start()
    {
        ctrl = GameObject.Find("GameManager").GetComponent<ControlManager>();    

        // pecahSource = GameObject.Find("pecahAudio");
        // pecah = pecahSource.GetComponent<AudioSource>();

        // wrongSource = GameObject.Find("wrongAudio");
        // wrong = wrongSource.GetComponent<AudioSource>();
        
        
    }
    // Update is called once per frame
    void Update()
    {
      Debug.Log("color id adalah" + colorId);
      
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-(150f + kecepatan), 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Batas")){
            Destroy(gameObject);
            ctrl.fail++;
        }
    }
    
    
}
