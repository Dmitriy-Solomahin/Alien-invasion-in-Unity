using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemyShipsControler enemiesController;
    private int enemiesCount;
    [SerializeField] private int level = 1;
    private bool gameIsActive = true;

    private void OnEnable() {
        EventManager.OnLevelsComplit += LevelUp;
        EventManager.OnGameOver += GameOver;
        EventManager.OnGameActive += GamePause;
    }

    private void OnDisable() {
        EventManager.OnLevelsComplit -= LevelUp;
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
    private void LevelUp() {
        level++;
        enemiesController.CreateEnemies(level);
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }

}
