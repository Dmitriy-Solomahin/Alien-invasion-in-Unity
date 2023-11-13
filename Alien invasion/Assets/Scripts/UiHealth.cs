using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealth : MonoBehaviour
{
    [SerializeField] GameObject[] healths;
    int health;
    void OnEnable() {
        EventManager.OnTakingDamage += TakingDamage;
    }
    void OnDisable() {
        EventManager.OnTakingDamage -= TakingDamage;
    }

    void Awake() {
        health = healths.Length;
    }

    void TakingDamage(){
        health--;
        healths[health].SetActive(false);
    }
}
