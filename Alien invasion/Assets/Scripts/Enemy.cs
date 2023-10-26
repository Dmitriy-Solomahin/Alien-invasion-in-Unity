using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyShipsControler parent;
    private void Start() {
        parent = transform.GetComponentInParent<EnemyShipsControler>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Gabarit"){
            if (other.gameObject.name == "Right"){
                parent.ShipsTurn(-1);
            }
            else if (other.gameObject.name == "Left"){
                parent.ShipsTurn(1);
            }
        }
    }
}
