using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsControler : MonoBehaviour
{
    [SerializeField] private GameObject prefabShip;
    private float speed = 1f;
    [SerializeField] private List<GameObject> ships;
    private int orientation = 1;
    private int numberOfEnemies = 7;
    private int level = 1;
    private Vector3 startPosition;

    private void OnEnable() {
        EventManager.OnKillingEnemy += EnemyDistroy;
    }
    private void OnDisable() {
        EventManager.OnKillingEnemy -= EnemyDistroy;
    }

    private void Awake() {
        ships = new List<GameObject>();
        startPosition = transform.position; 
        CreateEnemies();
    }
    private void Start() {
        EventManager.OnLevelsComplit.Invoke(level);
    }
    
    private void FixedUpdate() {
        transform.position += transform.right * orientation * speed * Time.fixedDeltaTime;
        if(ships.Count == 0) {
            level++;
            EventManager.OnLevelsComplit.Invoke(level);
            CreateEnemies();
        }
    }
    public void ShipsTurn(int orient) {
        if (orientation != orient){
            transform.position += transform.up * -0.25f;
            orientation = orient;
        }
    }
    public void CreateEnemies(){
        transform.position = startPosition;
        int y = 0;
        for (int i = 0, x = 0 ; i < numberOfEnemies * level; i++ ,x++)
        {
            if (i%7 == 0){
                y-= 2;
                x = 0;
            }
            GameObject ship = Instantiate(prefabShip, transform.position + new Vector3(2 * x, y, 0), Quaternion.identity);
            ship.transform.parent = transform;
            ships.Add(ship);
        }
    }
    private void EnemyDistroy(GameObject enemy)
    {
        ships.Remove(enemy);
    }

    public List<GameObject> GetListEnemies(){
        return ships;
    }
   
}
