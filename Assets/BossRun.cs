using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : MonoBehaviour
{
    // Start is called before the first frame update
    private float rightEdge = 115.75f;
    private float leftEdge = 99.75f;
    public float speed = 1;
    public Transform player;
    private int MoveDirection = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunIdle();
    }


    public void RunIdle()
    {
        if (transform.position.x > rightEdge || transform.position.x < leftEdge)
        {
            MoveDirection = -MoveDirection;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        
        transform.Translate(speed*Time.deltaTime* MoveDirection,0,0);
    }

    public void RunFight()
    {

    }

    public void PlayerIn()
    {

    }
    public void PlayerOut()
    {
        
    }

}
