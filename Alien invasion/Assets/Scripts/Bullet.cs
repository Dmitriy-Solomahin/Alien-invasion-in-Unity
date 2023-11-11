using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Essence
{
    private int orientation;
    private float speed = 5;
    
    private void Start() {
        Orientat();
    }
    
    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Gabarit") DestroyObj();
    }
    private void FixedUpdate() {
        Move();
    }

    private void Move()
    {
        transform.position += transform.up * speed * orientation * Time.fixedDeltaTime;
    }

    protected override void DestroyObj()
    {
        Destroy(this.gameObject);
    }

    private void Orientat(){
        orientation = gameObject.tag == "Enemy"? -1 : 1;
    }
}
