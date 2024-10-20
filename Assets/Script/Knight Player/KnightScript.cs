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
    public Transform attackPoint;
    public float radius;
    public LayerMask gameplayLayer;
    public bool canAttack;
    public float attackDamage;

    public bool isOnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        canAttack = true;
        attackDamage = 10;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            MoveDirection = -1;
            if(!anim.GetBool("IsFalling") && !anim.GetBool("IsJumping"))
            {
                anim.SetBool("IsRunning", true);
            }
            gameObject.transform.localScale = new Vector3( -Math.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveDirection = 1;
            if(!anim.GetBool("IsFalling") && !anim.GetBool("IsJumping"))
            {
                anim.SetBool("IsRunning", true);
            }
            gameObject.transform.localScale = new Vector3( Math.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
 
        }
        else
        {
            MoveDirection = 0;
            anim.SetBool("IsRunning", false);

        }
        transform.Translate(new Vector3(MoveDirection * speed * Time.deltaTime,0,0));

        if(Input.GetKeyDown(KeyCode.F) && canAttack == true)
        {
            anim.SetTrigger("IsAttack");
            canAttack = false;
            Attack();
            Invoke("EndAttack", 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            anim.SetBool("IsJumping",true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsFalling",false);
            rb.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
        }

        if(anim.GetBool("IsJumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("IsJumping",false);
            }
        }

        if (isOnGround == false && rb.velocity.y<0 )
        {
            anim.SetBool("IsFalling",true);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("IsFalling", false);
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position,radius, gameplayLayer);
        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log(enemy);
            if(enemy.GetComponent<BossData>() != null)
            {
                enemy.GetComponent<BossData>().Damage(attackDamage);
                Debug.Log("Attack Enemy");
            }
        }
    }
    
    public void EndAttack()
    {
        canAttack = true;
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,radius);
    }
}
 
