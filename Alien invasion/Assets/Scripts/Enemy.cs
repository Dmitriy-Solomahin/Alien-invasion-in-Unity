using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    EnemyShipsControler parent;
    GameObject shield;
    float timer;
    float maxValueTimer = 12;
    float minValueTimer = 4;
    
    void Start() {
        shield = transform.GetChild(0).gameObject;
        RaiseShield();
        parent = transform.GetComponentInParent<EnemyShipsControler>();
        RefreshTimer();
    }
    void Update() {   
        timer -= Time.deltaTime;
        if (timer <= 0){
            Shot();
            RefreshTimer();
        }
    }
    void RefreshTimer()
    {
        timer = UnityEngine.Random.Range(minValueTimer, maxValueTimer);
    }
    protected override void DestroyObj()
    {
        base.DestroyObj();
        EventManager.OnKillingEnemy?.Invoke(gameObject);
    }
    protected override void OnCollisionEnter2D(Collision2D other) {
        base.OnCollisionEnter2D(other);
        if (other.gameObject.tag == "Gabarit"){
            if (other.gameObject.name == "Right"){
                parent.TurnEnemies(-1);
            }
            else if (other.gameObject.name == "Left"){
                parent.TurnEnemies(1);
            }
            else if (other.gameObject.name == "Down"){
                EventManager.OnGameOver?.Invoke();
            }
        }
    }
    void RaiseShield(){
        if (hp > 1)shield.SetActive(true);
        else shield.SetActive(false);
    }
    protected override void HPUpdate(){
        base.HPUpdate();
        RaiseShield();
    }
}
