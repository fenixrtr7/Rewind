using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public int currentLevel = 1;
    // public enum GameState
    // {
    //     PREGAME,
    //     RUNNING,
    //     PAUSED,
    //     POSTGAME
    // }

    // GameState _currentGameState = GameState.PREGAME;

    // public GameState CurrentGameState
    // {
    //     get { return _currentGameState; }
    //     set { _currentGameState = value; }

    // private int _points;
    // public int Points
    // {
    //     get { return _points; }
    //     set { _points = value; }
    // }

    private void Start() {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
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
        currentLevel++;
        ChangeScene(currentLevel);
    }

}

