using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreaScript : MonoBehaviour
{
    
    bool playerInArea = false;
    public GameObject boss;
    // public BoxCollider2D coll;

    // void Start()
    // {
    //     coll = this.gameObject.GetComponent<BoxCollider2D>();
    // }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            boss.GetComponent<BossRun>().PlayerIn();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            boss.GetComponent<BossRun>().PlayerOut();
        }
    }
}
