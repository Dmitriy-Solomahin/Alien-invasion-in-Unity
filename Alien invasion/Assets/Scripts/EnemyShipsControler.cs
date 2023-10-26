using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsControler : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject prefabShip;
    private List<GameObject> ships;
    private int orientation = 1;
    private int numberOfEnemies = 14;

    private void Awake() {
        ships = new List<GameObject>();
        CreateEnemies();
    }

    private void FixedUpdate() {
        transform.position += transform.right * orientation * speed * Time.fixedDeltaTime;
    }
    public void ShipsTurn(int orient) {
        if (orientation != orient){
            transform.position += transform.up * -0.25f;
            orientation = orient;
        }
    }
    private void CreateEnemies(){
        int y = 0;
        for (int i = 0, x = 0 ; i < numberOfEnemies; i++ ,x++)
        {
            if (i == 7){
                y-= 2;
                x = 0;
            }
            GameObject ship = Instantiate(prefabShip, transform.position + new Vector3(2 * x, y, 0), Quaternion.identity);
            ship.transform.parent = transform;
            ships.Add(ship);
        }
    }
   
}
