using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EssenceEnemy
{
    [SerializeField] GameObject prefabBang;
    EnemyShipsControler parent;
    GameObject shield;
    int armor;
    float timer;
    float maxValueTimer = 12;
    float minValueTimer = 4;
    [SerializeField] GameObject prefabBullet;
    
    void Start() {
        shield = transform.GetChild(0).gameObject;
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

    void Shot()
    {
        Instantiate(prefabBullet, transform.position - new Vector3(0,-0.5f,0),transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D other) {
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
    void RaiseShield(int arm){
        armor = arm;
        shield.SetActive(true);
    }
    void TakeDamage(int damage){
        armor -= damage;
        if (armor == 0) shield.SetActive(false);
        else if (armor < 0){
            Instantiate(prefabBang, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
