using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    public void Resume(){
        EventManager.OnGameActive?.Invoke(true);
    }
}
