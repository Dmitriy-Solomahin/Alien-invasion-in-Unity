using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioSource gameOverSound;
    private EnemyShipsControler enemiesController;
    [SerializeField] private GameObject buletParent;
    private GameObject player;
    private bool gameIsActive = true;

    private void OnEnable() {
        EventManager.OnGameOver += GameOver;
        EventManager.OnGameActive += GamePause;
        EventManager.OnLevelsComplit += NextLevel;
    }    
    private void OnDisable() {
        EventManager.OnGameOver -= GameOver;
        EventManager.OnGameActive -= GamePause;
        EventManager.OnLevelsComplit -= NextLevel;
    }
    private void Start() {
        player = transform.GetChild(0).GetComponent<GameObject>();
        enemiesController = transform.GetChild(2).GetComponent<EnemyShipsControler>();
        gameOverSound = transform.GetComponent<AudioSource>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameIsActive = !gameIsActive;
            EventManager.OnGameActive?.Invoke(gameIsActive);
        }
    }
    private void NextLevel(int level){
        CildrenDelete(buletParent.transform);
        player.transform.position = new Vector3(0,player.transform.position.y,player.transform.position.z);
    }
    private void GamePause(bool isActive){
        gameIsActive = isActive;
        Time.timeScale = Convert.ToInt32(gameIsActive);
    }
    private void GameOver(){
        Debug.Log("GameOver");
        gameOverSound.Play();
    }
    private void CildrenDelete(Transform parent){
        foreach(Transform cildren in parent){
            Destroy(cildren.gameObject);
        }
    }
}
