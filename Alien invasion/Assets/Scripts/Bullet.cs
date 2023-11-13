using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Essence
{
    int orientation;
    float speed = 5;
    
    void Start() {
        Orientat();
    }
    
    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Gabarit") DestroyObj();
    }
    void FixedUpdate() {
        Move();
    }

    void Move()
    {
        transform.position += transform.up * speed * orientation * Time.fixedDeltaTime;
    }

    protected override void DestroyObj()
    {
        Destroy(this.gameObject);
    }

    void Orientat(){
        orientation = gameObject.tag == "Enemy"? -1 : 1;
    }
}
