using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsControler : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private int orientation = 1;
    private void FixedUpdate() {
        transform.position += transform.right * orientation * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Gabarit"){
            transform.position += transform.up * -0.25f;
            orientation *= -1;
        }
    }
   
}
