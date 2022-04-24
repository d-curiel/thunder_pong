using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Dictionary<int, float> _difficultyLevels = new Dictionary<int, float>();
    float _difficulty;
    bool gameStarted = false;
    int maxPoints = 11;

    GameObject _player1;
    GameObject _player2;
    public static GameManager _instance = null;
    private void Awake()
    {
        _difficultyLevels.Add(0, 6.5f);
        _difficultyLevels.Add(1, 7f);
        _difficultyLevels.Add(2, 7.5f);

        int difficulty = PlayerPrefs.GetInt("Difficulty");
        _difficulty = _difficultyLevels[difficulty];

        if (_instance == null)
        {
            _instance = this;
        }

        _player1 = GameObject.Find("Player1");
        _player2 = GameObject.Find("Player2");
        _player1.GetComponent<PlayerController>().enabled = true;
        _player2.GetComponent<PlayerController>().enabled = PlayerPrefs.GetInt("PlayerCount") != 1;
        _player2.GetComponent<IAController>().enabled = PlayerPrefs.GetInt("PlayerCount") == 1;
        
        _player2.GetComponent<IAController>().SetSpeed(_difficulty);
        StartGame();

    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
    public void StartGame()
    {
        gameStarted = true;
    }

    public void PauseGame()
    {
        gameStarted = false;
    }
    public void CheckPlayerWon(int score, string playerName)
    {
        if (score >= maxPoints)
        {
            Debug.Log(playerName + " won the game");
            PauseGame();
        }
    }
    public float GetDifficulty()
    {
        return _difficulty;
    }

}
