using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip [] buttonSounds;

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



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _singlePlayerButton.onClick.AddListener(OnSinglePlayerButtonClick);
        _easyButton.onClick.AddListener(OnEasyButtonClick);
        _mediumButton.onClick.AddListener(OnMediumButtonClick);
        _hardButton.onClick.AddListener(OnHardButtonClick);
        _multiPlayerButton.onClick.AddListener(OnMultiPlayerButtonClick);
    }

    private void OnSinglePlayerButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[0]);
        _easyButton.gameObject.SetActive(true);
        _mediumButton.gameObject.SetActive(true);
        _hardButton.gameObject.SetActive(true);
        _singlePlayerButton.gameObject.SetActive(false);
        _multiPlayerButton.gameObject.SetActive(false);
    }

    private void OnEasyButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
    }

    private void OnMediumButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
    }

    private void OnHardButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[1]);
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayerPrefs.SetInt("PlayerCount", 1);
        ChangeToGameScene();
    }

    private void OnMultiPlayerButtonClick()
    {
        audioSource.PlayOneShot(buttonSounds[0]);
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("PlayerCount", 2);
        ChangeToGameScene();
    }

    void ChangeToGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
