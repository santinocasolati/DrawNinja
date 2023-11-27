using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentLevel;
    public Level[] levels;
    public Action playerDeath;
    public Action<string> levelCompleted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        playerDeath += PlayerDeathHandler;
        levelCompleted += LevelCompletedHandler;
    }

    private void OnDisable()
    {
        playerDeath -= PlayerDeathHandler;
        levelCompleted -= LevelCompletedHandler;
    }

    private void PlayerDeathHandler()
    {
        LoadLevel("Defeat");
    }

    private void LevelCompletedHandler(string nextLevel)
    {
        LoadLevel(nextLevel);

        if (nextLevel == "Level1" || nextLevel == "Level2")
        {
            currentLevel = nextLevel;
        }
    }

    public void LoadLevel(string level)
    {
        Level[] l = levels.Where(l => l.name == level).ToArray();

        if (l.Length == 0) return;

        Level changeLevel = l[0];

        SceneManager.LoadScene(changeLevel.scene.name);
    }
}

[System.Serializable]
public class Level
{
    public SceneAsset scene;
    public string name;
}
