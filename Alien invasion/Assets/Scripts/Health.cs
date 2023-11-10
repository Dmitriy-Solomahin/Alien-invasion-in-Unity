using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health;
    public int GetHealth(){
        return health;
    }
    public void TakingDamage(int damage){
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}
