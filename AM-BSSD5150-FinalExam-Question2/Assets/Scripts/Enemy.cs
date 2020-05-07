using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Vector2 direction;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private GameObject b;
    [SerializeField] private GameObject a;
    public AudioMixerSnapshot scape;
    public AudioSource scapeee;
    private float transitionTime = 1f;
    private float distance;

    Rigidbody2D rb;
    RaycastHit hit;
    [SerializeField] float maxSpeed = 3f;
    float move = 1;

    public float range = 100f;

    private Collider coll;

    // Start is called before the first frame update
    void Start()
    { rb = GetComponent<Rigidbody2D>(); }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    { if (other.gameObject.tag == "edge")
        { FlipSprite();} }


//check distance and check facing
    void Update()
    { distance = (checkpoint.transform.position.x - transform.position.x);
        //was trying to use raycast to check facing.
        RaycastHit hit;
       Ray ray = new Ray(transform.position, Vector2.right);

       if (ray.direction == ray.direction)
       {
           Debug.Log("facing");
       }
       if (distance < 3)
       {
           Destroy(GameObject.FindWithTag("edge")); 
           scape.TransitionTo(transitionTime);
           scapeee.Play();
       }
     
       Vector3 dirFromAtoB = (b.transform.position - a.transform.position).normalized;
       float dotProd = Vector3.Dot(dirFromAtoB, a.transform.forward);
 
       if(dotProd > 0.9) {
           // ObjA is looking mostly towards ObjB
           Debug.Log("lolo");
       }
    }
    
private void FlipSprite()
        {//move the enemy

            Vector3 spriteScale = transform.localScale;
            spriteScale.x *= -1;
            transform.localScale = spriteScale;
            move *= -1;
        }

        Transform target; // planet transform


        void FixedUpdate()
        { rb.velocity = new Vector2(move * maxSpeed, 0);} }

    
    
    
    
 
    
