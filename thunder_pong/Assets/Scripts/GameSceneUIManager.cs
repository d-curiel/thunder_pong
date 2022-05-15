using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameSceneUIManager : MonoBehaviour
{
    [SerializeField]
    Button _btnPause;
    [SerializeField]
    Button _btnResume;
    [SerializeField]
    Button _btnQuit;
    [SerializeField]
    Button _confirmQuit;
    [SerializeField]
    Button _cancelQuit;
    [SerializeField]
    Image _pausePanel;
    [SerializeField]
    Image _quitPanel;

    [SerializeField]
    Image _winningPanel;

    [SerializeField]
    Image _instructionsPanel;
    [SerializeField]
    Text _winningText;
    [SerializeField]
    Button _btnRestart;
    [SerializeField]
    Button _btnQuitToMenu;
    [SerializeField]
    Button _startGameButton;
    public static GameSceneUIManager _instance;

    AudioSource audioSource;
    [SerializeField]
    AudioClip[] buttonSounds;
    [SerializeField]
    AudioClip _winningSound;

    [SerializeField]
    AudioClip _loseSound;
    BackgroundMusicController _backgroundMusicController;
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _backgroundMusicController = FindObjectOfType<BackgroundMusicController>();
        audioSource = GetComponent<AudioSource>();
        _btnPause.onClick.AddListener(OnPauseButtonClick);
        _btnResume.onClick.AddListener(OnResumeButtonClick);
        _btnQuit.onClick.AddListener(OnQuitButtonClick);
        _confirmQuit.onClick.AddListener(OnConfirmQuitButtonClick);
        _cancelQuit.onClick.AddListener(OnCancelQuitButtonClick);
        _btnRestart.onClick.AddListener(OnRestartButtonClick);
        _btnQuitToMenu.onClick.AddListener(OnConfirmQuitButtonClick);
        _startGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager._instance.IsGameStarted())
            {
                OnPauseButtonClick();
            }
            else
            {
                OnResumeButtonClick();
            }
        }
    }

    void OnStartGameButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[0]);
        _instructionsPanel.gameObject.SetActive(false);
        GameManager._instance.StartGame();
    }
    void OnPauseButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        PauseGame();
    }

    void OnResumeButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[0]);
        ResumeGame();
    }

    void OnQuitButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        _quitPanel.gameObject.SetActive(true);
    }

    void OnConfirmQuitButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void OnCancelQuitButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[0]);
        _quitPanel.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        _btnPause.enabled = false;
        _pausePanel.gameObject.SetActive(true);
        _backgroundMusicController.StopMusic();
        GameManager._instance.ChangeGameStarted();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _btnPause.enabled = true;
        _pausePanel.gameObject.SetActive(false);
        _backgroundMusicController.ResumeMusic();
        GameManager._instance.ChangeGameStarted();
        Time.timeScale = 1;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ShowWinningPanel(string playerName)
    {
        audioSource.PlayOneShot(_winningSound);
        _winningPanel.gameObject.SetActive(true);
        _winningText.text = "Gana " + playerName;
    }

    public void ShowGameOverPanel()
    {
        audioSource.PlayOneShot(_loseSound);
        _winningPanel.gameObject.SetActive(true);
        _winningText.text = "Has perdido\n¿Desea volver a jugar?";
    }

    public void changeVisibilitiInstructionsPanel(bool value)
    {
        _instructionsPanel.gameObject.SetActive(value);
    }
}
