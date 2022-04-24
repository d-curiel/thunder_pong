using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Button _singlePlayerButton;
    [SerializeField]
    private Button _easyButton;
    [SerializeField]
    private Button _mediumButton;
    [SerializeField]
    private Button _hardButton;
    [SerializeField]
    private Button _multiPlayerButton;
    [SerializeField]
    private Button _optionsButton;



    private void Start()
    {
        _singlePlayerButton.onClick.AddListener(OnSinglePlayerButtonClick);
        _easyButton.onClick.AddListener(OnEasyButtonClick);
        _mediumButton.onClick.AddListener(OnMediumButtonClick);
        _hardButton.onClick.AddListener(OnHardButtonClick);
        _multiPlayerButton.onClick.AddListener(OnMultiPlayerButtonClick);
        _optionsButton.onClick.AddListener(OnOptionsButtonClick);
    }

    private void OnSinglePlayerButtonClick()
    {
        _easyButton.gameObject.SetActive(true);
        _mediumButton.gameObject.SetActive(true);
        _hardButton.gameObject.SetActive(true);
        Debug.Log("Single Player Button Clicked");
    }

    private void OnEasyButtonClick()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
        Debug.Log("Easy Button Clicked");
    }

    private void OnMediumButtonClick()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
        Debug.Log("Medium Button Clicked");
    }

    private void OnHardButtonClick()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
        Debug.Log("Hard Button Clicked");
    }

    private void OnMultiPlayerButtonClick()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("PlayerCount", 2);
        ChangeToGameScene();
        Debug.Log("Multi Player Button Clicked");
    }

    void ChangeToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnOptionsButtonClick()
    {
        Debug.Log("Options Button Clicked");
    }
}
