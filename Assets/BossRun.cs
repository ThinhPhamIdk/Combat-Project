using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BossRun : MonoBehaviour
{
    // Start is called before the first frame update
    private float rightEdge = 115.75f;
    private float leftEdge = 99.75f;
    public float speed = 0.5f;
    public Transform player;
    private int MoveDirection = 1;
    public bool IsPlayerIn;
    
    void Start()
    {
        IsPlayerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerIn)
        {
            RunFight();
        }
        else
        {
            RunIdle();
        }
    }


    public void RunIdle()
    {
        if (transform.position.x > rightEdge- 0.1 || transform.position.x < leftEdge + 0.1)
        {
            MoveDirection = -MoveDirection;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        
        transform.Translate(speed*Time.deltaTime* MoveDirection,0,0);
    }

    public void RunFight()
    {

        
        //Turn the Boss to the player
        if(gameObject.transform.position.x < player.position.x)
        {
            Debug.Log("Move RIGHT");
            MoveDirection = -1;
            transform.localScale = new Vector3(-math.abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            Debug.Log("Move LEFT");
            MoveDirection = 1;
            transform.localScale = new Vector3(math.abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (   math.abs( (float)(  gameObject.transform.position.x - player.position.x)) > 3 ) 
        {
            transform.Translate(speed*Time.deltaTime*MoveDirection,0,0);
        }
        else
        {
            this.GetComponent<BossAttack>().Attack();
        }
    }

    public void PlayerIn()
    {
        IsPlayerIn = true;
    }
    public void PlayerOut()
    {
        IsPlayerIn = false;
    }

}
