using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public LevelEvent levelEvent;
    public LevelState levelState;

    TextMeshProUGUI scoreDisplay;

    void Awake()
    {
        InitListeners();
        GetComponents();
    }


    void Start() {
        IncrementScore();
    }


    void IncrementScore() {
        scoreDisplay.text = levelState.CurrentScore.ToString();
    }


    void InitListeners() {
        levelEvent.OnBlockBroke += IncrementScore;    
    }


    void GetComponents() {
        scoreDisplay = gameObject.GetComponent<TextMeshProUGUI>();
    }

}
