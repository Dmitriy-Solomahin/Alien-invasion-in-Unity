using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    // [SerializeField] int guns = 1;
    [SerializeField] AudioSource damageAudio;
    Animation anim;
    float speed = 5;
    float move;
    int ships = 3;

    void Update() {
        move = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)) Shot();
    }
    void Start() {
        anim = gameObject.GetComponent<Animation>();
        health.SetHealth(ships);
    }
    void FixedUpdate() {
        if (move != 0) PlayerMove();
    }
    protected override void DestroyObj()
    {
        base.DestroyObj();
        EventManager.OnGameOver?.Invoke();
    }
    protected override void HPUpdate(){
        int oldHP = hp;
        base.HPUpdate();
        oldHP -= hp;
        for (int i = 0; i < oldHP; i++)
        {
            EventManager.OnTakingDamage?.Invoke();
        }
        if (hp > 0){
            anim.Play();
            damageAudio.Play();
        } 
    }
    void PlayerMove()
    {
        transform.position += transform.right * move * speed * Time.fixedDeltaTime;
    }
    
}
