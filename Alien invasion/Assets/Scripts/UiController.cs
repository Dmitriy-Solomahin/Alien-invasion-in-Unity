using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private GameObject windowPause;
    private void OnEnable() {
        EventManager.OnGameActive += Pause;
    }
    private void OnDisable() {
        EventManager.OnGameActive -= Pause;
    }
    private void Start() {
        windowPause = transform.GetChild(1).gameObject;
    }

    private void Pause(bool isActive)
    {
        windowPause.SetActive(!isActive) ;
    }
}
