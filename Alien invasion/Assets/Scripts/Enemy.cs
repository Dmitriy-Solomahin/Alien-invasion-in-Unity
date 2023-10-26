using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyShipsControler parent;
    private float timer;
    private float maxValueTimer = 12;
    private float minValueTimer = 4;
    [SerializeField] private GameObject prefabBullet;
    
    private void Start() {
        parent = transform.GetComponentInParent<EnemyShipsControler>();
        RefreshTimer();
    }
    private void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Shot();
            RefreshTimer();
        }
    }

    private void RefreshTimer()
    {
        timer = UnityEngine.Random.Range(minValueTimer, maxValueTimer);
    }

    private void Shot()
    {
        Instantiate(prefabBullet, transform.position - new Vector3(0,-0.5f,0),transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Gabarit"){
            if (other.gameObject.name == "Right"){
                parent.ShipsTurn(-1);
            }
            else if (other.gameObject.name == "Left"){
                parent.ShipsTurn(1);
            }
            else if (other.gameObject.name == "Down"){
                EventManager.OnGameOver?.Invoke();
            }
        }
    }
}
