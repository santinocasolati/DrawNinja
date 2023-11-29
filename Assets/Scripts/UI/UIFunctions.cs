using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    public void Play()
    {
        LevelManager.instance.PlayGame();
    }

    public void Retry()
    {
        LevelManager.instance.Retry();
    }

    public void Menu()
    {
        LevelManager.instance.GoToMenu();
    }

    public void NextLevel()
    {
        LevelManager.instance.NextLevel();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
