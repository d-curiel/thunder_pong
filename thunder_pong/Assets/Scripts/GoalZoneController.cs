using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GoalZoneController : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    int score;

    [SerializeField]
    GameObject _player;
    
    [SerializeField]
    AudioClip goalSound;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
        scoreText.text = score.ToString();
        
    }
    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            audioSource.PlayOneShot(goalSound);
            score++;
            scoreText.text = score.ToString();
            other.gameObject.GetComponent<BallController>().InitBallAfterScore();
            GameManager._instance.CheckPlayerWon(score, _player);
        }
    }

}
