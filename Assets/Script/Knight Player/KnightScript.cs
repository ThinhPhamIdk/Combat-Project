using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class MovingScript : MonoBehaviour
{
    private int MoveDirection = 0;
    private Animator anim;
    public float speed;
    public float jumpPower;
    private Rigidbody2D rb;

    public bool isOnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is pressed");
            MoveDirection = -1;
            anim.SetBool("IsRunning", true);
            gameObject.transform.localScale = new Vector3( -Math.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D is pressed");
            MoveDirection = 1;
            anim.SetBool("IsRunning", true);
            gameObject.transform.localScale = new Vector3( Math.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
 

        }
        else
        {
            MoveDirection = 0;
            anim.SetBool("IsRunning", false);

        }
        transform.Translate(new Vector3(MoveDirection * speed * Time.deltaTime,0,0));
 
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collide with" + " " + other.gameObject);
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Exit collide with" + " " + other.gameObject);
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

}
 
