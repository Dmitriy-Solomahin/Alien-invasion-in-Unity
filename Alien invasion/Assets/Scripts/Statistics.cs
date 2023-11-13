using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    int score = 0;
    int maxScore;
    int level;
    [SerializeField] Text scoreText;
    void OnEnable() {
        EventManager.OnKillingEnemy += ScoringPoints;
        EventManager.OnLevelsComplit += СhangeLevel;
    }
    void OnDisable() {
        EventManager.OnKillingEnemy -= ScoringPoints;
        EventManager.OnLevelsComplit -= СhangeLevel;
    }    
    void ScoringPoints(GameObject enemy){
        score += level * 5; 
        UiScoreUpdate();
        if (score > maxScore) maxScore = score;
    }
    void СhangeLevel(int lvl)
    {
        level = lvl;
    }
    void UiScoreUpdate(){
        scoreText.text = score.ToString();
    }

}
