using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    Essence obj;
    private void Awake() {
        obj = gameObject.GetComponent<Essence>();
    }
    public int GetHealth(){
        return health;
    }
    public void SetHealth(int hp){
        health = hp;
    }
    public void TakingDamage(int damage){
        health -= damage;
        if (health <= 0) obj.DestroyObject();
        obj.HealthIndicationUpdate();
    }
}
