using UnityEngine;
using System.Collections;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance ?? (instance = new GameManager()); } }

    public LevelManager LevelManager;

    public bool isPaused = false;
    public bool isInGame = false;
    public bool isMouseOverUI = false;

    private GameManager()
    {
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
