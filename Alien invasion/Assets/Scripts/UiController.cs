using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    GameObject windowPause;
    void OnEnable() {
        EventManager.OnGameActive += Pause;
    }
    void OnDisable() {
        EventManager.OnGameActive -= Pause;
    }
    void Start() {
        windowPause = transform.GetChild(1).gameObject;
    }

    void Pause(bool isActive)
    {
        windowPause.SetActive(!isActive) ;
    }
}
