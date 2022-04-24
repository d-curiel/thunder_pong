using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZoneController : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    int score;
    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
        
    }
    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            score++;
            scoreText.text = score.ToString();
            other.gameObject.GetComponent<BallController>().InitBallAfterScore();
        }
    }

}
