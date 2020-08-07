﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class GameManager : Manager<GameManager>
{
    public int currentLevel = 1;
    public enum GameState
    {
        MENU,
        RUNNING,
        PAUSED,
        GAMEOVER
    }

    public Events.EventGameState OnGameStateChanged;

    GameState _currentGameState = GameState.MENU;
    int numberScenes;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }

    // private int _points;
    // public int Points
    // {
    //     get { return _points; }
    //     set { _points = value; }
    }

    private void Start()
    {
        //Debug.Log("Number of scenes: " + SceneManager.sceneCountInBuildSettings);

        DontDestroyOnLoad(gameObject);

        currentLevel = SceneManager.GetActiveScene().buildIndex;
        numberScenes = SceneManager.sceneCountInBuildSettings - 1;

        //Debug.Log("number Scenes: " + numberScenes + "current Level: " + currentLevel);
    }

    public void StarGame()
    {
        UpdateState(GameState.RUNNING);
        UIManager.Instance.ActivePanelControls();
        NextLevel();
    }


    public void GameOver()
    {
        UpdateState(GameState.GAMEOVER);
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public void GoMenu()
    {
        UpdateState(GameState.MENU);
    }

    // Cambiar estado de juego
    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.MENU:
                Time.timeScale = 1.0f;
                break;

            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;

            case GameState.GAMEOVER:
                Time.timeScale = 1.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void NextLevel()
    {
        //Debug.Log("number Scenes: " + numberScenes + "current Level: " + currentLevel);

        if (numberScenes == currentLevel)
        {
            StartCoroutine(UIManager.Instance.WinPanel());
            // Win
            //Debug.Log("win");
            currentLevel = 0;
            GoMenu();
            ChangeScene(currentLevel);
            // On win and send menu
        }
        else
        {
            currentLevel++;
            ChangeScene(currentLevel);
        }

    }

    public void ResetLevel()
    {
        ChangeScene(currentLevel);
    }
}

