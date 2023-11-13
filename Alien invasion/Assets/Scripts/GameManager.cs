using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource gameOverSound;
    EnemyShipsControler enemiesController;
    GameObject player;
    bool gameIsActive = true;

    void OnEnable() {
        EventManager.OnGameOver += GameOver;
        EventManager.OnGameActive += GamePause;
        EventManager.OnLevelsComplit += NextLevel;
    }    
    void OnDisable() {
        EventManager.OnGameOver -= GameOver;
        EventManager.OnGameActive -= GamePause;
        EventManager.OnLevelsComplit -= NextLevel;
    }
    void Start() {
        player = transform.GetChild(0).gameObject;
        enemiesController = transform.GetChild(2).GetComponent<EnemyShipsControler>();
        gameOverSound = transform.GetComponent<AudioSource>();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameIsActive = !gameIsActive;
            EventManager.OnGameActive?.Invoke(gameIsActive);
        }
    }
    void NextLevel(int level){
        player.GetComponent<Player>().DeliteBullets();
        player.transform.position = new Vector3(0,player.transform.position.y,player.transform.position.z);
        //StartCoroutine(WaitBetweenLevels()); ломает игру!!!
        enemiesController.CreateEnemies();
    }
    void GamePause(bool isActive){
        gameIsActive = isActive;
        Time.timeScale = Convert.ToInt32(gameIsActive);
    }
    void GameOver(){
        Debug.Log("GameOver");
        gameOverSound.Play();
    }
    // void CildrenDelete(Transform parent){
    //     foreach(Transform cildren in parent){
    //         Destroy(cildren.gameObject);
    //     }
    //}
    IEnumerator WaitBetweenLevels(){
        yield return new WaitForSeconds(0.5f);
        enemiesController.CreateEnemies();
    }
}
