using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemyShipsControler enemiesController;
    private int enemiesCount;
    [SerializeField] private int level = 1;

    private void OnEnable() {
        EventManager.OnLevelsComplit += LevelUp;
        EventManager.OnGameOver += GameOver;
    }

    private void OnDisable() {
        EventManager.OnLevelsComplit -= LevelUp;
        EventManager.OnGameOver -= GameOver;
    }

    private void Start() {
        enemiesController = transform.GetChild(2).GetComponent<EnemyShipsControler>();
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
