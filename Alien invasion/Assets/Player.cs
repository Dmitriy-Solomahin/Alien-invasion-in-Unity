using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int helth = 3;
    [SerializeField] private int guns = 1;
    [SerializeField] private int dameg = 1;
    [SerializeField] private GameObject bullet;
    private float speed = 5;
    private float move;

    private void Update() {
        move = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)) Shot();
    }

    private void FixedUpdate() {
        if (move != 0) PlayerMove();
    }

    private void PlayerMove()
    {
        transform.position += transform.right * move * speed * Time.fixedDeltaTime;
    }

    private void Shot()
    {
        Instantiate(bullet, transform.position + new Vector3(0,0.5f,0),transform.rotation);
    }
}
