using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject prefabBang;
    private int dameg = 1;
    private float speed = 5;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            dameg--;
            Instantiate(prefabBang, transform.position, Quaternion.identity);
            EventManager.OnKillingEnemy?.Invoke(other.gameObject);
            Destroy(other.gameObject);
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
