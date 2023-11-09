using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemyShipsControler enemiesController;
        private bool gameIsActive = true;

    private void OnEnable() {
        EventManager.OnGameOver += GameOver;
        EventManager.OnGameActive += GamePause;
    }    
    private void OnDisable() {
        EventManager.OnGameOver -= GameOver;
        EventManager.OnGameActive -= GamePause;
    }
    private void Start() {
        enemiesController = transform.GetChild(2).GetComponent<EnemyShipsControler>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameIsActive = !gameIsActive;
            EventManager.OnGameActive?.Invoke(gameIsActive);
        }
    }
    private void GamePause(bool isActive){
        gameIsActive = isActive;
        Time.timeScale = Convert.ToInt32(gameIsActive);
    }
    private void GameOver()
    {
        Debug.Log("GameOver");
    }

}
