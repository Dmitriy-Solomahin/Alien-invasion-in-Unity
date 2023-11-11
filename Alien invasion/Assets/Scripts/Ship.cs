using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : Essence
{
    [SerializeField] GameObject prefabBang;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] AudioSource shotAudio;
    protected int damage = 1;
    protected virtual void OnCollisionEnter2D(Collision2D other) {
        TakingDamage(other.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        TakingDamage(other.gameObject);
    }

    private void TakingDamage(GameObject other)
    {
        if (other.tag != gameObject.tag && (other.tag == "Enemy" || other.tag == "Player")){
            Health otherHealth = other.GetComponent<Health>();
            int otherHP = otherHealth.GetHealth();
            int oldHP = hp;
            health.TakingDamage(otherHP);
            otherHealth.TakingDamage(oldHP);
            HPUpdate();
        }
    }
    protected override void DestroyObj()
    {
        Instantiate(prefabBang, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    protected virtual void Shot(){
        GameObject bullet = Instantiate(prefabBullet, transform.position - new Vector3(0, 0.5f,0),transform.rotation);
        bullet.tag = gameObject.tag;
        bullet.GetComponent<Health>().SetHealth(damage);
        //shotAudio?.Play();
    }
}