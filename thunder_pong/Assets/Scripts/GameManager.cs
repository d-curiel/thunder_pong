using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Dictionary<int, float> _difficultyLevels = new Dictionary<int, float>();
    float _difficulty;
    [SerializeField]
    bool gameStarted = false;
    int maxPoints = 1;

    GameObject _player1;
    GameObject _player2;
    public static GameManager _instance = null;
    BackgroundMusicController _backgroundMusicController;
    private void Awake()
    {
        _backgroundMusicController = FindObjectOfType<BackgroundMusicController>();
        _difficultyLevels.Add(0, 7.5f);
        _difficultyLevels.Add(1, 8f);
        _difficultyLevels.Add(2, 8.5f);

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

    void Update()
    {
    }
    public bool IsGameStarted()
    {
        return gameStarted;
    }
    public void StartGame()
    {
        gameStarted = true;
    }
    public void ChangeGameStarted()
    {
        gameStarted = !gameStarted;
    }

    public void CheckPlayerWon(int score, GameObject winningPlayer)
    {
        if (score >= maxPoints)
        {
            Time.timeScale = 0;
            gameStarted = false;
            _backgroundMusicController.StopMusic();
            if (winningPlayer.tag == "Player")
            {
                GameSceneUIManager._instance.ShowWinningPanel("Jugador 1");
            }
            else
            {
                if (winningPlayer.GetComponent<IAController>().enabled)
                {
                    GameSceneUIManager._instance.ShowGameOverPanel();
                }
                else
                {
                    GameSceneUIManager._instance.ShowWinningPanel("Jugador 2");
                }
            }

        }
    }
    public float GetDifficulty()
    {
        return _difficulty;
    }

}
