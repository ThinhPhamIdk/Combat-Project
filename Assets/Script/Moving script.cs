using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingscript : MonoBehaviour
{

    private int MoveDirection = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            MoveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D is pressed");
            MoveDirection = -1;
        }

        transform.Translate(new Vector3(MoveDirection,0,0));
    }
}
