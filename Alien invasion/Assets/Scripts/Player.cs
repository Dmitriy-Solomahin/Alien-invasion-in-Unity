using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    // [SerializeField] private int guns = 1;
    [SerializeField] private AudioSource damageAudio;
    private Animation anim;
    private float speed = 5;
    private float move;
    private int ships = 3;

    private void Update() {
        move = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)) Shot();
    }
    private void Start() {
        anim = gameObject.GetComponent<Animation>();
        health.SetHealth(ships);
    }
    private void FixedUpdate() {
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

    private void PlayerMove()
    {
        transform.position += transform.right * move * speed * Time.fixedDeltaTime;
    }
}
