using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int dameg = 1;
    private float speed = 5;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            dameg--;
        }
        if(other.gameObject.tag == "Gabarit"){
            dameg = 0;
        }
    }
    void Update()
    {
        if (dameg <= 0) Destroy(this.gameObject);
    }
    private void FixedUpdate() {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }
}
