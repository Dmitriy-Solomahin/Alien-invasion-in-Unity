using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Essence : MonoBehaviour
{
    protected Health health; 
    protected int hp;

    void Awake() {
        health = gameObject.GetComponent<Health>();
        hp = health.GetHealth();
    }
    public void DestroyObject(){
        DestroyObj();
    }
    public void HealthIndicationUpdate(){
        HPUpdate();
    }
    protected abstract void DestroyObj();
    protected virtual void HPUpdate(){
        hp = health.GetHealth();
    }
}
