using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    public float Health = 100;
    
    public void Damage(float damage)
    {
        this.Health -= damage;
    }
}
