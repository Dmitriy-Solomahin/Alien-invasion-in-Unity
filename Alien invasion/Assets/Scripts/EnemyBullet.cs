using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Gabarit"){
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate() {
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
}
