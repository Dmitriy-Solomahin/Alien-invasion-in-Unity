using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EssencePlayer : MonoBehaviour
{
    Health health; 
    int hp;
    private void OnCollisionEnter2D(Collision2D other) {
        TakingDamage(other.gameObject, true);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        TakingDamage(other.gameObject);
    }

    private void TakingDamage(GameObject other, bool isShip = false)
    {
        Health otherHealth = other.GetComponent<Health>();
        int otherHP = otherHealth.GetHealth();
        health.TakingDamage(otherHP);
        otherHealth.TakingDamage(hp);
        hp = health.GetHealth();
    }
}