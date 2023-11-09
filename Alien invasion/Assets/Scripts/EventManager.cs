using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action<GameObject> OnKillingEnemy;
    public static Action<int> OnLevelsComplit;
    public static Action OnGameOver;
    public static Action OnTakingDamage;
    public static Action<bool> OnGameActive;
}
