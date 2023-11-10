using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsControler : MonoBehaviour
{
    [SerializeField] GameObject prefabShip;
    [SerializeField] List<GameObject> ships;
    float speed = 1f;
    int orientation = 1;
    int numberOfEnemies = 7;
    int numberOfLineEnemies = 3;
    int level = 1;
    Vector3 startPosition;

    void OnEnable() {
        EventManager.OnKillingEnemy += DistroyEnemy;
    }
    void OnDisable() {
        EventManager.OnKillingEnemy -= DistroyEnemy;
    }

    void Awake() {
        ships = new List<GameObject>();
        startPosition = transform.position; 
        CreateEnemies();
    }
    void Start() {
        EventManager.OnLevelsComplit.Invoke(level);
    }
    
    void FixedUpdate() {
        transform.position += transform.right * orientation * speed * Time.fixedDeltaTime;
        if(ships.Count == 0) {
            level++;
            EventManager.OnLevelsComplit.Invoke(level);
            CreateEnemies();
        }
    }
    public void TurnEnemies(int orient) {
        if (orientation != orient){
            transform.position += transform.up * -0.25f;
            orientation = orient;
        }
    }
    void CreateEnemies(){
        transform.position = startPosition;
        int y = 0;
        for (int i = 0, x = 0 ; i < numberOfEnemies * numberOfLineEnemies; i++ ,x++)
        {
            if (i%numberOfEnemies == 0){
                y-= 2;
                x = 0;
            }
            GameObject ship = Instantiate(prefabShip, transform.position + new Vector3(2 * x, y, 0), Quaternion.identity);
            ship.transform.parent = transform;
            ships.Add(ship);
        }
    }
    void DistroyEnemy(GameObject enemy)
    {
        ships.Remove(enemy);
    }
    void CreateEnemy(){
        
    }
    public List<GameObject> GetListEnemies(){
        return ships;
    }
    
    
}
