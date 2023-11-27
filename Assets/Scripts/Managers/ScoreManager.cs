using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Action<int> healthChanged;
    public Action<int> scoreChanged;

    private int totalScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        healthChanged += healthChangedHandler;
        scoreChanged += scoreChangedHandler;
    }

    private void OnDisable()
    {
        healthChanged -= healthChangedHandler;
        scoreChanged -= scoreChangedHandler;
    }

    private void healthChangedHandler(int health)
    {
        HudItems.instance.health.text = health.ToString();
    }

    private void scoreChangedHandler(int score)
    {
        totalScore += score;
        HudItems.instance.score.text = totalScore.ToString();
    }
}
