using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] healths;
    private int health;
    private void OnEnable() {
        EventManager.OnTakingDamage += TakingDamage;
    }
    private void OnDisable() {
        EventManager.OnTakingDamage -= TakingDamage;
    }

    private void Awake() {
        health = healths.Length;
    }

    void TakingDamage(){
        health--;
        healths[health].SetActive(false);
    }
}
