using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

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

    public void PlayGame()
    {
        GameManager.instance.levelCompleted.Invoke("Level1");
    }

    public void Retry()
    {
        GameManager.instance.levelCompleted.Invoke(GameManager.instance.currentLevel);
    }

    public void GoToMenu()
    {
        GameManager.instance.levelCompleted.Invoke("MainMenu");
    }

    public void NextLevel()
    {
        if (GameManager.instance.currentLevel == "Level1")
        {
            GameManager.instance.levelCompleted.Invoke("Level2");
        } else
        {
            GameManager.instance.levelCompleted.Invoke("CompletedScene");
        }
    }
}
