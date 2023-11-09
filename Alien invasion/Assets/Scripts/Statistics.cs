using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    private int score = 0;
    private int maxScore;
    private int level;
    [SerializeField] private Text scoreText;
    private void OnEnable() {
        EventManager.OnKillingEnemy += ScoringPoints;
        EventManager.OnLevelsComplit += СhangeLevel;
    }
    private void OnDisable() {
        EventManager.OnKillingEnemy -= ScoringPoints;
        EventManager.OnLevelsComplit -= СhangeLevel;
    }    
    private void ScoringPoints(GameObject enemy){
        score += level * 5; 
        UiScoreUpdate();
        if (score > maxScore) maxScore = score;
    }
    private void СhangeLevel(int lvl)
    {
        level = lvl;
    }
    private void UiScoreUpdate(){
        scoreText.text = score.ToString();
    }

}
