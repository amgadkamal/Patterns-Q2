using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    private float move2;
    private float maxSpeedx = 2f;
    private float maxSpeedy = 2f;
    private float jump = 150f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        move2 = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FlipSprite();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FlipSprite();
        }
    }
    private void FixedUpdate()

    {
        //press space for jumping
        rb.velocity = new Vector2(move * maxSpeedx, move2 * maxSpeedy);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(move * maxSpeedx, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x +jump,rb.velocity.y + jump);
        }
    }
    private void FlipSprite()
    {

        Vector3 spriteScale = transform.localScale;
        spriteScale.x *= -1;
        transform.localScale = spriteScale;
        move *= -1;
    }

   

    
}
